using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GeById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateBrandRequest request) {

            CreateBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest _pageRequest)
        {
            GetListResponse<GetListBrandListItemDto> response = await Mediator.Send(new GetListBrandQuery(_pageRequest));
            return Ok(response);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdBrandRequest getByIdBrandRequest = new() { Id = id,WithDelete=true };
            GetByIdBrandResponse response = await Mediator.Send(getByIdBrandRequest);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandRequest request)
        {

            UpdateBrandResponse response = await Mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteBrandResponse response = await Mediator.Send(new DeleteBrandRequest { Id = id });

            return Ok(response);
        }
    }
}

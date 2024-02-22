
using Application.Features.Models.Queries.GetistByDynamic;
using Application.Features.Models.Queries.GetList;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest Prequest)
        {
            return Ok(await Mediator.Send(new GetListModelQuery() { PageRequest = Prequest }));
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest Prequest, [FromBody] DynamicQuery? query = null)
        {
            return Ok(await Mediator.Send(new GetListByDynamicModelQuery() { PageRequest = Prequest, dynamicQuery = query }));
        }
    }
}

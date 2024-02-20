using Application.Features.Brands.Commands.Update;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandRequest:IRequest<DeleteBrandResponse>
    {
        public Guid Id { get; set; }

        public class DeleteBrandRequestHandler : IRequestHandler<DeleteBrandRequest, DeleteBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public DeleteBrandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBrandResponse> Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(x => x.Id == request.Id);
                brand = _mapper.Map(request, brand);

                await _brandRepository.DeleteAsync(brand);

                return new() { Id = request.Id };
            }
        }
    }
}

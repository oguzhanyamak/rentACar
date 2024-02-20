using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandRequest:IRequest<UpdateBrandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandRequestHandler : IRequestHandler<UpdateBrandRequest, UpdateBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public UpdateBrandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<UpdateBrandResponse> Handle(UpdateBrandRequest request, CancellationToken cancellationToken)
            {
                Brand? brand =await _brandRepository.GetAsync(x => x.Id == request.Id);
                brand = _mapper.Map(request, brand);

                await _brandRepository.UpdateAsync(brand);

                return _mapper.Map<UpdateBrandResponse>(brand);
            }
        }
    }
}

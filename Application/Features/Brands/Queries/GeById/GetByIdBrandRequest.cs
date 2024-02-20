using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GeById;

public class GetByIdBrandRequest : IRequest<GetByIdBrandResponse>
{
    public Guid Id { get; set; }
    public bool WithDelete { get; set; }

    public class GetByIdBrandRequestHandler : IRequestHandler<GetByIdBrandRequest, GetByIdBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public GetByIdBrandRequestHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<GetByIdBrandResponse> Handle(GetByIdBrandRequest request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, withDeleted: request.WithDelete, cancellationToken: cancellationToken);

            GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(brand);

            return response;
        }
    }
}

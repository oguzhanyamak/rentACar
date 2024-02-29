using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Logging;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandRequest : IRequest<CreateBrandResponse>, ITransactionalRequest, ICacheRemoverRequest,ILoggableRequest
{
    public string Name { get; set; }

    public string CacheKey => string.Empty;

    public bool ByPassCache => false;
    public string? CacheGroupKey => "GetBrands";

    public class CreateBrandRequestHandler : IRequestHandler<CreateBrandRequest, CreateBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinesRules _brandBusinesRules;

        public CreateBrandRequestHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinesRules brandBusinesRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinesRules = brandBusinesRules;
        }

        public async Task<CreateBrandResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
        {

            await _brandBusinesRules.BrandNameCannotBeDuplicatedWhenInsertedAsync(request.Name);
            var res = await _brandRepository.AddAsync(new() { Id = Guid.NewGuid(),Name = request.Name});

            return _mapper.Map<CreateBrandResponse>(res);
        }
    }
}

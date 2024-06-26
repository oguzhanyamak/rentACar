﻿using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Logging;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>, ICachableRequest,ILoggableRequest
    {
        public PageRequest PageRequest {  get; set; }

        public string CacheKey => $"GetListBrandQuery({PageRequest.PageIndex},{PageRequest.PageSize})";

        public bool ByPassCache { get; }

        public TimeSpan? SlidingExpiration {  get; }

        public string? CacheGroupKey => "GetBrands";

        public GetListBrandQuery()
        {
            
        }
        public GetListBrandQuery(PageRequest pageRequest)
        {
            PageRequest= pageRequest;
        }

        public class GetBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                Paginate<Brand> brands = await _brandRepository.GetListAsync(index : request.PageRequest.PageIndex,size:request.PageRequest.PageSize);
                return _mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
            }
        }
    }
}

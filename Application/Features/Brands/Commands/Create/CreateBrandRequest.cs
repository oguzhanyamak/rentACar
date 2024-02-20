using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandRequest : IRequest<CreateBrandResponse>
{
    public string Name { get; set; }

    public class CreateBrandRequestHandler : IRequestHandler<CreateBrandRequest, CreateBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<CreateBrandResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            var res = await _brandRepository.AddAsync(new() { Id = Guid.NewGuid(),Name = request.Name});

            return _mapper.Map<CreateBrandResponse>(res);
        }
    }
}

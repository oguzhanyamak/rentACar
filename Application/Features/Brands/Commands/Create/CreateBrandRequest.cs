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
        public Task<CreateBrandResponse> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

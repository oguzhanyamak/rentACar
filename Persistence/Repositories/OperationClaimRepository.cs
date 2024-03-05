using Application.Services.Repositories;
using Core.Persistence.Repository;
using Core.Security.Entities;
using Persistence.Context;

namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}

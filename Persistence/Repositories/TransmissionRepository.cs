using Core.Persistence.Repository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class TransmissionRepository : EfRepositoryBase<Transmission, Guid, BaseDbContext>
    {
        public TransmissionRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

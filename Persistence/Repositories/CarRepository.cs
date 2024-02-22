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
    public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>
    {
        public CarRepository(BaseDbContext context) : base(context)
        {
        }
    }
}

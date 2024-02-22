﻿using Application.Services.Repositories;
using Core.Persistence.Repository;
using Domain.Entities;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class ModelRepository : EfRepositoryBase<Model, Guid, BaseDbContext>,IModelRepository
{
    public ModelRepository(BaseDbContext context) : base(context)
    {
    }
}

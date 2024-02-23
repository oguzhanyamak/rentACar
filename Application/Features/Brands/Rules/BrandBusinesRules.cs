using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConserns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinesRules : BaseBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinesRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCannotBeDuplicatedWhenInsertedAsync(string name)
        {
            Brand? res = await _brandRepository.GetAsync(predicate:b=> b.Name.ToLower() == name.ToLower());

            if (res is not null)
            {
                throw new BusinessException(BrandMessages.BrandNameExists);
            }

        }
    }
}

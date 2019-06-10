using ApplicationServices.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System.Collections.Generic;

namespace ApplicationServices.Implementations
{
    public class BrandService
    {
        private GamesDbContext context = new GamesDbContext();

        public List<BrandDto> Get()
        {
            List<BrandDto> brandDtos = new List<BrandDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // foreach-ing each item in the repository, not in the context
                foreach (var item in unitOfWork.BrandRepository.Get())
                {
                    brandDtos.Add(new BrandDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Country = item.Country,
                        Description = item.Description
                    });
                }
            }
            return brandDtos;
        }


        public BrandDto GetById(int id)
        {
            BrandDto brandDto = new BrandDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Brand brand = unitOfWork.BrandRepository.GetByID(id);

                if (brand != null)
                {
                    brandDto = new BrandDto
                    {
                        Id = brand.Id,
                        Name = brand.Name,
                        Country = brand.Country,
                        Description = brand.Description
                    };
                }
            }

            return brandDto;
        }


        public bool Save(BrandDto brandDto)
        {
            Brand brand = new Brand
            {
                Id = brandDto.Id,
                Name = brandDto.Name,
                Country = brandDto.Country,
                Description = brandDto.Description
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (brandDto.Id == 0)
                    {
                        unitOfWork.BrandRepository.Insert(brand);
                    }
                    else
                    {
                        unitOfWork.BrandRepository.Update(brand);
                    }
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Brand brand = unitOfWork.BrandRepository.GetByID(id);
                    unitOfWork.BrandRepository.Delete(brand);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

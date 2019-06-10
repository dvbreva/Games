using ApplicationServices.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System.Collections.Generic;

namespace ApplicationServices.Implementations
{
    public class KindService
    {
        private GamesDbContext context = new GamesDbContext();


        public List<KindDto> Get()
        {
            List<KindDto> kindDtos = new List<KindDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // foreach-ing each item in the repository, not in the context
                foreach (var item in unitOfWork.KindRepository.Get())
                {
                    kindDtos.Add(new KindDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Suitability = item.Suitability
                    });
                }
            }
            return kindDtos;
        }


        public KindDto GetById(int id)
        {
            KindDto kindDto = new KindDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Kind kind = unitOfWork.KindRepository.GetByID(id);

                if (kind != null)
                {
                    kindDto = new KindDto
                    {
                        Id = kind.Id,
                        Name = kind.Name,
                        Description = kind.Description,
                        Suitability = kind.Suitability
                    };
                }
            }

            return kindDto;
        }


        public bool Save(KindDto kindDto)
        {
            Kind kind = new Kind
            {
                Id = kindDto.Id,
                Name = kindDto.Name,
                Description = kindDto.Description,
                Suitability = kindDto.Suitability
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (kindDto.Id == 0)
                    {
                        unitOfWork.KindRepository.Insert(kind);
                    }
                    else
                    {
                        unitOfWork.KindRepository.Update(kind);
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
                    Kind kind = unitOfWork.KindRepository.GetByID(id);
                    unitOfWork.KindRepository.Delete(kind);
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

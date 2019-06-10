using ApplicationServices.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System.Collections.Generic;

namespace ApplicationServices.Implementations
{
    public class GameService
    {
        private GamesDbContext context = new GamesDbContext();

        public List<GameDto> Get()
        {
            List<GameDto> gamesDto = new List<GameDto>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.GameRepository.Get())
                {
                    gamesDto.Add(new GameDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        PlayerCount = item.PlayerCount,
                        Brand = new BrandDto
                        {
                            Id = item.Brand.Id,
                            Name = item.Brand.Name,
                            Description = item.Brand.Description,
                            Country = item.Brand.Country
                        },
                        Kind = new KindDto
                        {
                            Id = item.Kind.Id,
                            Name = item.Kind.Name,
                            Description = item.Kind.Description,
                            Suitability = item.Kind.Suitability
                        }
                    });
                }
            }
            return gamesDto;
        }


        public GameDto GetById(int id)
        {
            GameDto GameDto = new GameDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Game game = unitOfWork.GameRepository.GetByID(id);
                if (game != null)
                {
                    GameDto = new GameDto
                    {
                        Name = game.Name,
                        Description = game.Description,
                        PlayerCount = game.PlayerCount,
                        Brand = new BrandDto
                        {
                            Id = game.Brand.Id,
                            Name = game.Brand.Name,
                            Description = game.Brand.Description,
                            Country = game.Brand.Country
                        },
                        Kind = new KindDto
                        {
                            Id = game.Kind.Id,
                            Name = game.Kind.Name,
                            Description = game.Kind.Description,
                            Suitability = game.Kind.Suitability
                        }
                    };
                }
            }

            return GameDto;
        }


        public bool Save(GameDto GameDto)
        {
           /* if (GameDto.Brand == null || GameDto.Kind == null)
            {
                return false;
            }
            */

            Brand Brand = new Brand
            {
                Name = GameDto.Brand.Name,
                Description = GameDto.Brand.Description,
                Country = GameDto.Brand.Country
            };

            Kind Kind = new Kind
            {
                Name = GameDto.Kind.Name,
                Description = GameDto.Kind.Description,
                Suitability = GameDto.Kind.Suitability
            };


            Game game = new Game
            {
                Id = GameDto.Id,
                Name = GameDto.Name,
                Description = GameDto.Description,
                PlayerCount = GameDto.PlayerCount,
                BrandId = GameDto.Brand.Id,
                KindId = GameDto.Kind.Id
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (GameDto.Id == 0)
                    {
                        unitOfWork.GameRepository.Insert(game);

                    }
                    else
                    {
                        unitOfWork.GameRepository.Update(game);
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
                    Game game = unitOfWork.GameRepository.GetByID(id);
                    unitOfWork.GameRepository.Delete(game);
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

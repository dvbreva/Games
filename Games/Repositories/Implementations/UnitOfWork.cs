using Data.Context;
using Data.Entities;
using System;

namespace Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private GamesDbContext context = new GamesDbContext();

        private GenericRepository<Game> gameRepository;
        private GenericRepository<Brand> brandRepository;
        private GenericRepository<Kind> kindRepository;


        public GenericRepository<Game> GameRepository
        {
            get
            {
                if (this.gameRepository == null)
                {
                    this.gameRepository = new GenericRepository<Game>(context);
                }
                return gameRepository;
            }
        }


        public GenericRepository<Brand> BrandRepository
        {
            get
            {
                if (this.brandRepository == null)
                {
                    this.brandRepository = new GenericRepository<Brand>(context);
                }
                return brandRepository;
            }
        }


        public GenericRepository<Kind> KindRepository
        {
            get
            {
                if (this.kindRepository == null)
                {
                    this.kindRepository = new GenericRepository<Kind>(context);
                }
                return kindRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }


        #region IDisposable Support
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}


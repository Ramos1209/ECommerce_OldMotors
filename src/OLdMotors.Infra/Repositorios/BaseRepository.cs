using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OldMotors.Domain.Interfaces.Generics;
using OLdMotors.Infra.Configuration;

namespace OLdMotors.Infra.Repositorios
{
    public class BaseRepository<TEntity> : IBaseRespository<TEntity>, IDisposable where TEntity : class
    {
        private readonly DbContextOptions<OldMotorsContext> _context;
        public BaseRepository()
        {
            _context = new DbContextOptions<OldMotorsContext>();
        }
        public async Task Add(TEntity entity)
        {
            using (var data = new OldMotorsContext(_context))
            {
                await data.Set<TEntity>().AddAsync(entity);
                await data.SaveChangesAsync();

            }
        }

        public async Task<TEntity> GetById(int id)
        {
            using (var data = new OldMotorsContext(_context))
            {
                return await data.Set<TEntity>().FindAsync(id);

            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            using (var data = new OldMotorsContext(_context))
            {
                return await data.Set<TEntity>().AsNoTracking().ToListAsync();

            }
        }

        public async Task Update(TEntity entity)
        {
            using (var data = new OldMotorsContext(_context))
            {
                data.Set<TEntity>().Update(entity);
                await data.SaveChangesAsync();

            }
        }

        public async Task Remover(int id)
        {
            using (var data = new OldMotorsContext(_context))
            {
                var obj = this.GetById(id);
                data.Remove(obj);
                await data.SaveChangesAsync();
            }
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}

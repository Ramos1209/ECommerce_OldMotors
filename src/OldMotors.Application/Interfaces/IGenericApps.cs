using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OldMotors.Application.Interfaces
{
   public interface IGenericApps<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remover(int id);
    }
}

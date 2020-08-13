using System.Collections.Generic;
using System.Threading.Tasks;

namespace OldMotors.Domain.Interfaces.Generics
{
   public interface IBaseRespository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remover(int id);
    }
}

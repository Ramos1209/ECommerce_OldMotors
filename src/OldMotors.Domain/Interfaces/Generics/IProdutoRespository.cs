using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OldMotors.Entityes.Entityes;

namespace OldMotors.Domain.Interfaces.Generics
{
   public interface IProdutoRespository: IBaseRespository<Produto>
    {
        Task<List<Produto>> ListaProdutoUsuario(string idUsuario);
    }
}

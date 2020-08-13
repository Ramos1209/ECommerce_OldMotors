using System.Collections.Generic;
using System.Threading.Tasks;
using OldMotors.Entityes.Entityes;

namespace OldMotors.Application.Interfaces
{
    public interface IProdutoApp : IGenericApps<Produto>
    {
        Task AddProduto(Produto produto);
        Task UpdateProduto(Produto produto);
        Task<List<Produto>> ListaProdutoUsuario(string idUsuario);
    }
}

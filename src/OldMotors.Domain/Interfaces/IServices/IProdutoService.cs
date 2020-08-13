using System.Threading.Tasks;
using OldMotors.Entityes.Entityes;

namespace OldMotors.Domain.Interfaces.IServices
{
   public interface IProdutoService
    {
        Task AddProduto(Produto produto);
        Task UpdateProduto(Produto produto);
    }
}

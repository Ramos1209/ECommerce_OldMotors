using System;
using System.Threading.Tasks;
using OldMotors.Domain.Interfaces.Generics;
using OldMotors.Domain.Interfaces.IServices;
using OldMotors.Entityes.Entityes;

namespace OldMotors.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRespository _respository; 
        public ProdutoService(IProdutoRespository respository)
        {
            _respository = respository;
        }
        public async Task AddProduto(Produto produto)
        {
            var validaProduto = produto.ValidarPropriedadeString(produto.Nome, "Nome");
            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");
             var validaQuantidadeEstoque = produto.ValidarPropriedadeInt(produto.QuantidadeEstoque, "QuantidadeEstoque");

            if (validaProduto && validaValor && validaQuantidadeEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _respository.Add(produto);
            }
        }

        public async Task UpdateProduto(Produto produto)
        {
            var validaProduto = produto.ValidarPropriedadeString(produto.Nome, "Nome");
            var validaValor = produto.ValidarPropriedadeDecimal(produto.Valor, "Valor");
             var validaQuantidadeEstoque = produto.ValidarPropriedadeInt(produto.QuantidadeEstoque, "QuantidadeEstoque");
            if (validaProduto && validaValor && validaQuantidadeEstoque)
            {

                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _respository.Update(produto);
            }
        }
    }
}

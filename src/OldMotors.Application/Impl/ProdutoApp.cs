using System.Collections.Generic;
using System.Threading.Tasks;
using OldMotors.Application.Interfaces;
using OldMotors.Domain.Interfaces.Generics;
using OldMotors.Domain.Interfaces.IServices;
using OldMotors.Entityes.Entityes;

namespace OldMotors.Application.Impl
{
    public class ProdutoApp : IProdutoApp
    {
        private readonly IProdutoRespository _produto;
        private readonly IProdutoService _produtoService;
        public ProdutoApp(IProdutoService produtoService, IProdutoRespository produto)
        {
            _produtoService = produtoService;
            _produto = produto;
        }

        public async Task AddProduto(Produto produto)
        {
            await _produtoService.AddProduto(produto);
        }

        public async Task UpdateProduto(Produto produto)
        {
            await _produtoService.UpdateProduto(produto);
        }

        public async Task Add(Produto entity)
        {
            await _produto.Add(entity);
        }

      
        public async Task<List<Produto>> GetAll()
        {
            return await _produto.GetAll();
        }

        public async Task<Produto> GetById(int id)
        {
            return await _produto.GetById(id);
        }

        public async Task Remover(int id)
        {
            await _produto.Remover(id);
        }

        public async Task Update(Produto entity)
        {
            await _produto.Update(entity);
        }

        public Task<List<Produto>> ListaProdutoUsuario(string idUsuario)
        {
          return  _produto.ListaProdutoUsuario(idUsuario);
        }
    }
}

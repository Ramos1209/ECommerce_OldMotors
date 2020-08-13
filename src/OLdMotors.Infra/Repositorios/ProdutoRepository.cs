using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OldMotors.Domain.Interfaces.Generics;
using OldMotors.Entityes.Entityes;
using OLdMotors.Infra.Configuration;

namespace OLdMotors.Infra.Repositorios
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRespository
    {
        private readonly DbContextOptions<OldMotorsContext> _context;
        public ProdutoRepository(DbContextOptions<OldMotorsContext> context)
        {
            _context = context;
        }
        public async Task<List<Produto>> ListaProdutoUsuario(string idUsuario)
        {
            using (var data = new OldMotorsContext(_context))
            {
                return await data.Produtos.Where(x => x.UserId == idUsuario).AsNoTracking().ToListAsync();
            }
        }
    }
}

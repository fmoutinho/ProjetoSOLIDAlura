using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoEFCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoEFCore()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.ToList();
        }
    }
}

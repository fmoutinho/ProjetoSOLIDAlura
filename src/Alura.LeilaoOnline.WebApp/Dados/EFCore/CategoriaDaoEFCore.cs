using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados.Interfaces;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoEFCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoEFCore(AppDbContext context)
        {
            _context = context;
        }

        public Categoria GetById(int id)
        {
            return _context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias
                .Include(c => c.Leiloes);
        }
    }
}

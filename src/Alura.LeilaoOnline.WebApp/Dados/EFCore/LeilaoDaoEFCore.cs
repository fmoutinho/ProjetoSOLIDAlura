using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDaoEFCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoEFCore(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Leilao> BuscaTodosOsLeiloes() => _context.Leiloes.Include(l => l.Categoria);
        public Leilao GetByID(int id) => _context.Leiloes.Find(id);
        public void Insert(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void Update(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void Delete(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}

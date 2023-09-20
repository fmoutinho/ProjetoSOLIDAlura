using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDaoEFCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoEFCore()
        {
            _context = new AppDbContext();
        }

        public void Delete(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }

        public IEnumerable<Leilao> GetAllWithCategoria()
        {
            return _context.Leiloes.Include(l => l.Categoria);
        }

        public Leilao GetByID(int id)
        {
            return _context.Leiloes.Find(id);
        }

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
    }
}

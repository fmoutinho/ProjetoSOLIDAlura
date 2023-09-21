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
        public IEnumerable<Leilao> GetAll() => _context.Leiloes.Include(l => l.Categoria);
        public Leilao GetById(int id) => _context.Leiloes.Find(id);
        public void Insert(Leilao entity)
        {
            _context.Leiloes.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Leilao entity)
        {
            _context.Leiloes.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Leilao entity)
        {
            _context.Leiloes.Remove(entity);
            _context.SaveChanges();
        }
    }
}

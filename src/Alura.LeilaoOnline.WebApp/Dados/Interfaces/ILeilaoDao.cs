using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ILeilaoDao
    {
        public IEnumerable<Leilao> GetAllWithCategoria();
        public void Insert(Leilao leilao);
        public void Update(Leilao leilao);
        public void Delete(Leilao leilao);
        public Leilao GetByID(int id);
    }
}

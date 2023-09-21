using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ILeilaoDao
    {
        IEnumerable<Leilao> BuscaTodosOsLeiloes();
        void Insert(Leilao leilao);
        void Update(Leilao leilao);
        void Delete(Leilao leilao);
        Leilao GetByID(int id);
    }
}

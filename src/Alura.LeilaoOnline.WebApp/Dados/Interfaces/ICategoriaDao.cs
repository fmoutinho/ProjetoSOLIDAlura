using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> ConsultaCategorias();
        Categoria ConsultaCategoriaPorId(int id);
    }
}

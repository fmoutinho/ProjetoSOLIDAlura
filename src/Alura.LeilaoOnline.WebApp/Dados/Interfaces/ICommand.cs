using System.Collections;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.Interfaces
{
    public interface ICommand<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

using Alura.LeilaoOnline.WebApp.Dados.Interfaces;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {

        ILeilaoDao _leilaoDao;
        ICategoriaDao _categoriaDao;

        public DefaultAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _leilaoDao.Insert(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _categoriaDao.GetAll();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _leilaoDao.GetById(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _leilaoDao.GetAll();
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = ConsultaLeilaoPorId(id);
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            ModificaLeilao(leilao);
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = ConsultaLeilaoPorId(id);
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            ModificaLeilao(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _leilaoDao.Update(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                _leilaoDao.Delete(leilao);
            }

        }
    }
}
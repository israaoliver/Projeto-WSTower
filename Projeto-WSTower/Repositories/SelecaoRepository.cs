using Projeto_WSTower.Contexts;
using Projeto_WSTower.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_WSTower.Repositories
{
    public class SelecaoRepository
    {
        JogadorRepository _jogadorRepository = new JogadorRepository();

        public Selecao BuscarPorId(int id)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                var selecao = ctx.Selecao.ToList();

                selecao.ForEach(s => s.Jogador = _jogadorRepository.Listar().Where(j => j.SelecaoId == s.Id).ToList());

                return ctx.Selecao.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Selecao> Listar()
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                var selecao = ctx.Selecao.ToList();

                selecao.ForEach(s => s.Jogador = _jogadorRepository.Listar().Where(j => j.SelecaoId == s.Id).ToList());

                return ctx.Selecao.ToList();
            }
        }

        public void Cadastrar(Selecao selecao)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                ctx.Selecao.Add(selecao);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                Selecao selecaoId = ctx.Selecao.Find(id);
                ctx.Selecao.Remove(selecaoId);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Selecao selecao)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                Selecao selecaoAtuaizada = ctx.Selecao.FirstOrDefault(x => x.Id == selecao.Id);
                selecaoAtuaizada.Nome = selecao.Nome;
                ctx.Selecao.Update(selecaoAtuaizada);
                ctx.SaveChanges();
            }
        }

    }
}

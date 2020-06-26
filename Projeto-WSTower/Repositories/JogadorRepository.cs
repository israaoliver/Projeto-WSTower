using Projeto_WSTower.Contexts;
using Projeto_WSTower.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_WSTower.Repositories
{
    public class JogadorRepository
    {
        CampeonatoContext ctx = new CampeonatoContext();

        public List<Jogador> Listar()
        {
            return ctx.Jogador.ToList();
        }

        public Jogador BuscarPorId(int id)
        {
            return ctx.Jogador.FirstOrDefault(x => x.Id == id);
        }
    }
}

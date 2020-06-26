using Microsoft.EntityFrameworkCore;
using Projeto_WSTower.Contexts;
using Projeto_WSTower.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_WSTower.Repositories
{
    public class ConfrontoRepository
    {
        public Jogo Confronto(int id)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                
                return ctx.Jogo.FirstOrDefault(j => j.Id == id);
            }
        }
    }
}

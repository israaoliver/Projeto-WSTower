using Microsoft.EntityFrameworkCore;
using Projeto_WSTower.Contexts;
using Projeto_WSTower.Domains;
using Projeto_WSTower.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Projeto_WSTower.Repositories
{
    public class PrincipalRepository
    {
        public List<JogoViewModel> Listar()
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                return ctx.Jogo.OrderByDescending(x => x.Data).Select(j => new JogoViewModel()
                {
                    Id = j.Id,
                    PlacarCasa = j.PlacarCasa,
                    PlacarVisitante = j.PlacarVisitante,
                    Estadio = j.Estadio,
                    DataJogo = Convert.ToDateTime(j.Data),
                    PenaltisCasa = j.PenaltisCasa,
                    PenaltisVisitante = j.PenaltisVisitante,
                    NomeCasa = j.SelecaoCasaNavigation.Nome,
                    NomeVisitante = j.SelecaoVisitanteNavigation.Nome
                }).ToList();
            }
        }

        public List<JogoViewModel> ListarPorData(DateTime data)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                return ctx.Jogo.Select(j => new JogoViewModel()
                {
                    Id = j.Id,
                    PlacarCasa = j.PlacarCasa,
                    PlacarVisitante = j.PlacarVisitante,
                    Estadio = j.Estadio,
                    DataJogo = j.Data,
                    PenaltisCasa = j.PenaltisCasa,
                    PenaltisVisitante = j.PenaltisVisitante,
                    NomeCasa = j.SelecaoCasaNavigation.Nome,
                    NomeVisitante = j.SelecaoVisitanteNavigation.Nome
                }).Where(x => x.DataJogo.Value.Year == data.Year && x.DataJogo.Value.Month == data.Month && x.DataJogo.Value.Day == data.Day).ToList();
            }
        }

        public List<JogoViewModel> ListarPorNome(string filtro)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                return ctx.Jogo.OrderByDescending(x => x.Data).Where(x => x.Estadio.Contains(filtro) || x.SelecaoCasaNavigation.Nome.Contains(filtro) || x.SelecaoVisitanteNavigation.Nome.Contains(filtro)).Select(j => new JogoViewModel()
                {
                    Id = j.Id,
                    PlacarCasa = j.PlacarCasa,
                    PlacarVisitante = j.PlacarVisitante,
                    Estadio = j.Estadio,
                    DataJogo = Convert.ToDateTime(j.Data),
                    PenaltisCasa = j.PenaltisCasa,
                    PenaltisVisitante = j.PenaltisVisitante,
                    NomeCasa = j.SelecaoCasaNavigation.Nome,
                    NomeVisitante = j.SelecaoVisitanteNavigation.Nome
                }).ToList();
            }
        }
        
        
    }
}

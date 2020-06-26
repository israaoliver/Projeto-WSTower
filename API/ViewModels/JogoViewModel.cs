using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_WSTower.ViewModels
{
    public class JogoViewModel
    {
        public int Id { get; set; }
        public int PlacarCasa { get; set; }
        public int PlacarVisitante { get; set; }
        public string Estadio { get; set; }
        public DateTime? DataJogo { get; set; }
        public int PenaltisCasa { get; set; }
        public int PenaltisVisitante { get; set; }
        public string NomeCasa { get; set; }
        public string NomeVisitante { get; set; }
    }
}

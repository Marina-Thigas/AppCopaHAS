using System;
using System.Collections.Generic;
using System.Text;

namespace AppCopaHAS.Models.DTOs
{
    public class JogoDTO
    {
        public int IdJogo { get; set; }
        public DateTime DataHora { get; set; }
        public string Estadio { get; set; }
        public string Cidade { get; set; }
        public string SelecaoMandante { get; set; }
        public int GolsMandante { get; set; }
        public int GolsDecisaoPenaltisMandante { get; set; }
        public string SelecaoVisitante { get; set; }
        public int GolsVisitante { get; set; }
        public int GolsDecisaoPenaltisVisitante { get; set; }
        public string TecnicoVisitante { get; set; } = string.Empty;
    }
}

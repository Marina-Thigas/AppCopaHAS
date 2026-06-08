using System;
using System.Collections.Generic;
using System.Text;

namespace AppCopaHAS.Models
{
    public class JogoSelecao
    {
        public int JogoId { get; set; }
        public int SelecaoId { get; set; }
        public int Gols { get; set; }
        public int GolsDecisaoPenaltis { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCopaHAS.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int EstadioId { get; set; }
        public List<JogoSelecao> JogoSelecoes { get; set; } = new List<JogoSelecao>();
    }
}

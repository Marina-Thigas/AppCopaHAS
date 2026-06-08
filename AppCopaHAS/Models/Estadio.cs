using System;
using System.Collections.Generic;
using System.Text;

namespace AppCopaHAS.Models
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public decimal Capacidade { get; set; }

    }
}

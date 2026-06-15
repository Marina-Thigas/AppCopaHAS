using System;
using System.Collections.Generic;
using System.Text;

namespace AppCopaHAS.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public int NumeroCamisa { get; set; }
        public string Posicao { get; set; } = string.Empty;
        public byte[]? Foto { get; set; } // Array de bytes para obter a imagem

        public ImageSource FotoSource
        {
            get
            {
                if (Foto == null || Foto.Length == 0)
                    return "semfoto.png";

                return ImageSource.FromStream(() =>
                    new MemoryStream(Foto));
            }
        }
    }
}

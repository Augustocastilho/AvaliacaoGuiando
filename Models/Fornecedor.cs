using System;
using System.Drawing;

namespace AvaliacaoGuiando.Models
{
    public class Fornecedor
    {
        public int idFornecedor { get; set; }
        public String nome { get; set; }
        public String vertical { get; set; }
        public String link { get; set; }
        public Bitmap logo { get; set; }
        public Boolean historico { get; set; }
    }
}

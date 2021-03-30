using System;

namespace AvaliacaoGuiando.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Vertical { get; set; }
        public String Link { get; set; }
        public bool Historico { get; set; }
    }
}

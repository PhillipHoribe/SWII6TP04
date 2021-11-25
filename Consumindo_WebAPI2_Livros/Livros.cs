using System;
using System.Collections.Generic;
using System.Text;

namespace Consumindo_WebAPI2_Livros
{
    class Livros
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
    }
}

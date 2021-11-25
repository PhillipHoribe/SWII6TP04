using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Livros.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
    }
}
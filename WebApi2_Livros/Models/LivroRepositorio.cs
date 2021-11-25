using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2_Livros.Models
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private List<Livro> livros = new List<Livro>();
        private int _nextId = 1;

        public LivroRepositorio()
        {
            Add(new Livro { Titulo = "A", Categoria = "AA", Preco = 4.59M , Autor = "Autor a"});
            Add(new Livro { Titulo = "B", Categoria = "BB", Preco = 5.75M , Autor = "Autor b" });
            Add(new Livro { Titulo = "C", Categoria = "CC", Preco = 3.90M , Autor = "Autor c" });
            Add(new Livro { Titulo = "D", Categoria = "CC", Preco = 2.99M , Autor = "Autor d" });
            Add(new Livro { Titulo = "E", Categoria = "DD", Preco = 6.50M , Autor = "Autor e" });
            Add(new Livro { Titulo = "F", Categoria = "EE", Preco = 4.25M , Autor = "Autor f" });
        }

        public Livro Add(Livro item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            livros.Add(item);
            return item;
        }

        public Livro Get(int id)
        {
            return livros.Find(p => p.Id == id);
        }

        public IEnumerable<Livro> GetAll()
        {
            return livros;
        }

        public void Remove(int id)
        {
            livros.RemoveAll(p => p.Id == id);
        }

        public bool Update(Livro item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = livros.FindIndex(p => p.Id == item.Id);

            if (index == -1)
            {
                return false;
            }
            livros.RemoveAt(index);
            livros.Add(item);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Livros.Models;

namespace WebApi2_Livros.Controllers
{
    public class LivrosController : ApiController
    {
        static readonly ILivroRepositorio repositorio = new LivroRepositorio();
        public IEnumerable<Livro> GetAllProdutos()
        {
            return repositorio.GetAll();
        }
        public Livro GetProduto(int id)
        {
            Livro item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<Livro> GetProdutosPorCategoria(string categoria)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.Categoria, categoria, StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostProduto(Livro item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Livro>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutProduto(int id, Livro produto)
        {
            produto.Id = id;
            if (!repositorio.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteProduto(int id)
        {
            Livro item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}

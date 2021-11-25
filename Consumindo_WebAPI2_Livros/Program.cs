using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Consumindo_WebAPI2_Livros
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadKey(); static async Task RunAsync()
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri("https://localhost:44332/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("api/livros/1");
                    int c;
                    var cha = new Livros();
                    string titulo, categoria, autor;
                    decimal preco;
                    Console.WriteLine("menu/n 1-Adicionar um livro/n2-Exibir/n3-Atualizar/n4-Deletar");
                    c = int.Parse(Console.ReadLine());
                    if (response.IsSuccessStatusCode)
                    {
                        Uri chaUrl = response.Headers.Location;
                        switch (c)
                        {
                            case '1':
                                perguntas();
                                cha = new Livros() { Titulo = titulo, Categoria = categoria, Autor = autor, Preco = preco };
                                response = await client.PostAsJsonAsync("api/produtos", cha);
                                Console.WriteLine("Livro" + titulo + "incluído.");
                                Console.ReadKey();
                                break;
                            case '2':
                                Livros livro = await response.Content.ReadAsAsync<Livros>();
                                Console.WriteLine("{0}\tR${1}\t{2}", livro.Titulo, livro.Categoria, livro.Autor, livro.Preco);
                                Console.WriteLine("Livro acessado e exibido.");
                                Console.ReadKey();
                                break;
                            case '3': 
                                perguntas();
                                cha.Titulo = titulo;
                                cha.Autor = autor;
                                cha.Categoria = categoria;
                                cha.Preco = preco;
                                response = await client.PutAsJsonAsync(chaUrl, cha);
                                Console.WriteLine("Preço do Livro atualizado. Tecle algo para excluir o livro");
                                Console.ReadKey();
                                break;
                            case '4':
                                Console.WriteLine("ID:");
                                string id = Console.ReadLine();
                                response = await client.DeleteAsync(id);
                                Console.WriteLine("Livro deletado");
                                Console.ReadKey();
                                break;
                        }
                    }
                     void perguntas()
                    {
                        Console.WriteLine("Titulo");
                        titulo = Console.ReadLine();
                        Console.WriteLine("Categoria");
                        categoria = Console.ReadLine();
                        Console.WriteLine("Autor");
                        autor = Console.ReadLine();
                        Console.WriteLine("Preco");
                        preco = Decimal.Parse(Console.ReadLine());
                    }
                }
            }
        }
    }
}

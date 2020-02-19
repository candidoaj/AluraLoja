using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //DeletarProduto();
            //RecuperarProdutos();
            AlterarProduto();
        }

        private static void AlterarProduto()
        {
            GravarUsandoEntity();
            RecuperarProdutos();

            using (var ctx = new LojaContext())
            {
                var produto = ctx.Produtos.First();

                produto.Nome += " alterado";
                ctx.Produtos.Update(produto);
                ctx.SaveChanges();
            }

            RecuperarProdutos();
        }

        private static void DeletarProduto()
        {
            using (var ctx = new LojaContext())
            {
                var produtos = ctx.Produtos.ToList();

                foreach (var item in produtos)
                {
                    ctx.Produtos.Remove(item);
                }

                ctx.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();

                Console.WriteLine($"Foram encontrados {produtos.Count} produto(s)");

                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var context = new LojaContext())
            {
                context.Produtos.Add(p);
                context.SaveChanges();
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Fabrica.Models;
using Fabrica.Services;

namespace Pedido.Services
{
    public class PedidoService
    {
        private FabricaService fabricaService;

        public PedidoService(FabricaService fabricaService)
        {
            this.fabricaService = fabricaService; //um comando onde eu peço pro sistema pegar o valor do fabrica e guardar lá mesmo
        }

        public void CriarReceita()
        {
            Console.WriteLine("=== CRIAR RECEITA DE PRODUÇÃO ===");

            Console.Write("Digite o ID do produto: ");

            if (!int.TryParse(Console.ReadLine(), out int idProduto))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            MostrarProduto(idProduto);
        }

        public void MostrarProduto(int idProduto)
        {
            var produtoEncontrado = fabricaService.produtos.FirstOrDefault(p => p.ID == idProduto);

            if (produtoEncontrado == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine("\n=== PRODUTO SELECIONADO ====");
            Console.WriteLine($"ID: {produtoEncontrado.ID}");
            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
        }

        public void CriarPedidoProducao (int idProduto)
        {
            Console.WriteLine("=== Criação de pedido ====");
            MostrarProduto(idProduto);
        }
    }
}
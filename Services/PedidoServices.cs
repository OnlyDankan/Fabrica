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
            this.fabricaService = fabricaService;
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


        public void MostrarMateria(int idMateria)
        {
            var materiaEncontrada = fabricaService.materias.FirstOrDefault(m => m.ID == idMateria);

            if(materiaEncontrada == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine("\n=== MATERIA SELECIONADA ===");
            Console.WriteLine($"\nID: {materiaEncontrada.ID}");
            Console.WriteLine($"Nome: {materiaEncontrada.Nome}");
            Console.WriteLine($"Quantidade: {materiaEncontrada.Quantidade}");


            Console.WriteLine($"{materiaEncontrada.Nome}");
            Console.WriteLine("\n");


        }

    public void CriarPedidoProducao()
    {
    Console.WriteLine("\n=== CRIAR PEDIDO DE PRODUÇÃO ===");

    if (!fabricaService.produtos.Any())
    {
        Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    Console.WriteLine("\nProdutos disponíveis:");

    foreach (var produto in fabricaService.produtos)
    {
        Console.WriteLine($"ID: {produto.ID} - {produto.Nome}");
    }

    Console.Write("\nDigite o ID do produto: ");

    if (!int.TryParse(Console.ReadLine(), out int idProduto))
    {
        Console.WriteLine("ID inválido.");
        return;
    }

    var produtoSelecionado = fabricaService.produtos
        .FirstOrDefault(p => p.ID == idProduto);

    if (produtoSelecionado == null)
    {
        Console.WriteLine("Produto não encontrado.");
        return;
    }

    Console.WriteLine($"\nProduto selecionado: {produtoSelecionado.Nome}");

    Console.Write("Digite a quantidade a produzir: ");

    if (!int.TryParse(Console.ReadLine(), out int quantidade))
    {
        Console.WriteLine("Quantidade inválida.");
        return;
    }

    if (quantidade <= 0)
    {
        Console.WriteLine("A quantidade deve ser maior que zero.");
        return;
    }

    Console.WriteLine("\nSelecione a prioridade:");
    Console.WriteLine("1 - Baixa");
    Console.WriteLine("2 - Normal");
    Console.WriteLine("3 - Alta");

    Console.Write("Opção: ");

    if (!int.TryParse(Console.ReadLine(), out int opcaoPrioridade))
    {
        Console.WriteLine("Opção inválida.");
        return;
    }

    string prioridade;

    switch (opcaoPrioridade)
    {
        case 1:
            prioridade = "Baixa";
            break;

        case 2:
            prioridade = "Normal";
            break;

        case 3:
            prioridade = "Alta";
            break;

        default:
            Console.WriteLine("Prioridade inválida.");
            return;
    }

    var novoPedido = new PedidoProducao
    {
        ID = fabricaService.pedidos.Count + 1,
        Nome = produtoSelecionado.Nome,
        Quantidade = quantidade,
        Prioridade = prioridade,
        Status = "Aguardando"
    };

    fabricaService.pedidos.Add(novoPedido);

    Console.WriteLine("\nPedido criado com sucesso!");
    Console.WriteLine($"Produto: {produtoSelecionado.Nome}");
    Console.WriteLine($"Quantidade: {quantidade}");
    Console.WriteLine($"Prioridade: {prioridade}");
    Console.WriteLine($"Status: {novoPedido.Status}");
}
    }
}
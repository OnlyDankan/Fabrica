using System;
using Fabrica.Services;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Fabrica
{
    public class Program
    {
        static void Main(string[] args)
        {

            FabricaService fabricaService = new FabricaService();

            Console.WriteLine("=== FABRICA ===");

            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Atualizar produto");
            Console.WriteLine("4 - Remover produto");
            
            Console.WriteLine("\n5 - Cadastrar matéria-prima");
            Console.WriteLine("6 - Listar máteria-prima");
            Console.WriteLine("7 - Atualizar matéria-prima");

            Console.WriteLine("\n8 - Criar receita de produção");
            Console.WriteLine("9 - Criar pedido de produção");

            Console.WriteLine("\n10 - Ver pedidos");
            Console.WriteLine("11 - Verificar se pedido pode ser produzido");
            Console.WriteLine("12 - Iniciar produção");
            Console.WriteLine("13 - Finalizar produção");

            Console.WriteLine("\n14 - Relatórios");
            
            Console.WriteLine("\n0 - Sair");
            Console.WriteLine("Escolha uma opção: ");
            int menuOpcao = int.Parse(Console.ReadLine() ?? "");

            Console.Clear();

            switch (menuOpcao)
            {
                case 1:
                    fabricaService.CadastrarProduto();
                break;
            }
 
            
        }
    }
}
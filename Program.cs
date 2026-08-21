using System;
using Fabrica.Services;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Fabrica.Models;
using Pedido.Services;

namespace Fabrica
{
    public class Program
    {
        static void Main(string[] args)
        {

            FabricaService fabricaService = new FabricaService();
            PedidoService pedidoService = new PedidoService(fabricaService);
            

            bool executando = true;

            while (executando) {

            Console.WriteLine("=== FABRICA ===");

            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listagens");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Remover itens");
            

            Console.WriteLine("\n5 - Criar receita de produção");
            Console.WriteLine("6 - Criar pedido de produção");
            Console.WriteLine("7 - Ver pedidos");

            Console.WriteLine("8 - Verificar se pedido pode ser produzido");
            Console.WriteLine("9 - Iniciar produção");
            Console.WriteLine("10 - Finalizar produção");

            Console.WriteLine("\n11 - Relatórios");
            
            Console.WriteLine("\n0 - Sair");
            Console.Write("Escolha uma opção: ");
            int menuOpcao = int.Parse(Console.ReadLine() ?? "");

            Console.Clear();

            switch (menuOpcao)
            {
                case 1:
                    fabricaService.Cadastros();
                break;

                case 2:
                    fabricaService.Listagens();
                break;

                case 3:
                    fabricaService.Atualizar();                
                break;

                case 4:
                    fabricaService.Remover();
                break;

                case 5:
                    pedidoService.CriarReceita();
                break;

                case 6:
                    
                break;

                case 0:
                    executando = false;
                    Console.WriteLine("Encerrando o sistema...");
                break;

                default:
                    Console.WriteLine("Opção inválida.");
                break;
            }   

            if (executando)
                {
                    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }            
           }
        }
    }
}
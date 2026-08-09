using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Data;
using Fabrica.Models;



namespace Fabrica.Services
{
    public class FabricaService
    {
        private List<Produto> produtos = new List<Produto>(); 
        private List<MateriaPrima> materias = new List<MateriaPrima>();
        private List<PedidoProducao> pedidos = new List<PedidoProducao>();

        public void Cadastros()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Deseja cadastrar qual item?");

                    Console.WriteLine("\n1 - Produto");
                    Console.WriteLine("2 - Máteria-Prima");
        
                    int opcao = int.Parse(Console.ReadLine() ?? "");

                    Console.Clear();

                    switch (opcao) {

                    case 1:   
                    Console.WriteLine("==== Cadastro de produto ====");

                    Console.Write("\nNome: ");
                    string nome = Console.ReadLine() ?? "";
                    Produto? produtoEncontrado = produtos.FirstOrDefault(f => f.Nome == nome);

                    if (produtoEncontrado != null)
                    {
                        throw new ArgumentException("Este nome já existe. Tente novamente.");
                    }

                    if (string.IsNullOrWhiteSpace(nome))
                    {
                        throw new ArgumentException("O campo não pode ser vazio. Tente novamente");
                    }


                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine() ?? "");
                    Produto? produtoEncontrados = produtos.FirstOrDefault(f => f.ID == id);

                    if (produtoEncontrados != null)
                    {
                        throw new ArgumentException("Este ID já existe. Tente novamente");
                    }

                    if (int.IsNegative(id))
                    {
                        throw new ArgumentException("Número não válido");
                    }

                    Produto produto = new Produto();

                    produto.Nome = nome;
                    produto.ID = id;

                    produtos.Add(produto);

                    Console.WriteLine("Produto cadastrado.");
                    break;




                    case 2:
                    Console.WriteLine("==== Cadastro de Matéria-Prima ====");

                    Console.Write("\nID: ");
                    int idMateria = int.Parse(Console.ReadLine() ?? "");
                    MateriaPrima? materiaEncontrada = materias.FirstOrDefault(m => m.ID == idMateria);

                    if (materiaEncontrada != null)
                    {
                        throw new ArgumentException("Este ID já está cadastrado. Tente novamente");
                    }
                    if (int.IsNegative(idMateria))
                    {
                        throw new ArgumentException("Número inválido");      
                    }  


                    Console.Write("Nome: ");
                    string nomeMateria = Console.ReadLine() ?? "";
                    MateriaPrima? materiasEncontrada = materias.FirstOrDefault(m => m.Nome == nomeMateria);
                    
                    if (materiasEncontrada != null)
                    {
                        throw new ArgumentException("Este item já está cadastrado. Tente novamente");              
                    }
                    
                    if (string.IsNullOrWhiteSpace(nomeMateria))
                    {
                        throw new ArgumentException("Número inválido");
                    }

                    Console.Write("Quantidade: ");
                    int quantidadeMateria = int.Parse(Console.ReadLine() ?? "");
                    

                    if (int.IsNegative(quantidadeMateria))
                    {
                        throw new ArgumentException("Número inválido.");                    
                    }

                    MateriaPrima materia = new MateriaPrima();

                    materias.Add(materia);

                    materia.ID = idMateria;
                    materia.Nome = nomeMateria;
                    materia.Quantidade = quantidadeMateria;


                    Console.WriteLine("Produto cadastrado.");

                    break;
                    
                }

                } catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                } catch (FormatException)
                {
                    Console.WriteLine("Digite um valor válido.");
                }
            }
        }





        public void Listagens()
        {
            Console.WriteLine("=== LISTAGENS ====");
            
                Console.WriteLine("\n1- Produtos");
                Console.WriteLine("2 - Matérias-Primas");
                Console.WriteLine("0 - Voltar");
                int opcao = int.Parse(Console.ReadLine() ?? "");

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        foreach (Produto produto in produtos)
                    {
                        Console.WriteLine("=== PRODUTOS REGISTRADOS ====");
                        Console.WriteLine($"\nNome: {produto.Nome}");
                        Console.WriteLine($"ID: {produto.ID}");

                        Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        return; 
                    }   
                    break;


                    case 2:

                        foreach (MateriaPrima materiaPrima in materias) 
                        {
                        Console.WriteLine("==== MATÉRIAS-PRIMAS REGISTRADAS ====");
                        Console.WriteLine($"\nNome: {materiaPrima.Nome}");
                        Console.WriteLine($"ID: {materiaPrima.ID}");
                        Console.WriteLine($"Quantidade: {materiaPrima.Quantidade}");

                        Console.WriteLine("Aperte qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        return;
                        }
                    break;

                }
        }

            public void Atualizar()
        {
            Console.Clear();
            
            while (true)
            {
                try
                {
                 Console.WriteLine("Digite o ID do item que você deseja atualizar: ");
                 string attId = Console.ReadLine() ?? ""; 
                } catch
                {
                    
                }
            }
        }



    }
}
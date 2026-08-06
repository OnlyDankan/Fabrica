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
        private List<Produto> produtos = new List<Produto>(); //ajustar mais tarde essa list
        private List<MateriaPrima> materias = new List<MateriaPrima>();

        public void CadastrarProduto()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Deseja cadastrar qual item?");

                    Console.WriteLine("1 - Produto");
                    Console.WriteLine("2 - Máteria-Prima");
                    Console.WriteLine("3 - Pedidos");
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

                    Console.Write("ID: ");
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
                    string Nome = Console.ReadLine() ?? "";
                    MateriaPrima? materiasEncontrada = materias.FirstOrDefault(m => m.Nome == Nome);
                    
                    if (materiasEncontrada != null)
                    {
                        throw new ArgumentException("Este item já está cadastrado. Tente novamente");              
                    }
                    
                    if (string.IsNullOrWhiteSpace(Nome))
                    {
                        throw new ArgumentException("Número inválido");
                    }

                    Console.Write("Quantidade: ");
                    int QuantidadeMateria = int.Parse(Console.ReadLine() ?? "");
                    

                    if (int.IsNegative(QuantidadeMateria))
                    {
                        throw new ArgumentException("Número inválido.");                    
                    }

                    MateriaPrima materia = new MateriaPrima();

                    materias.Add(materia);

                    Console.WriteLine("Produto cadastrado.");
                    return;

                    //break;
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
                Console.WriteLine("3 - Pedidos");
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
                        Console.WriteLine($"Nome: {materiaPrima.Nome}");
                        }
                    break;
                }



                
            
        }



    }
}
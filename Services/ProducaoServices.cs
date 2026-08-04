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

        public void CadastrarProduto()
        {
            while (true)
            {
                try
                {
                    Console.Write("Cadastro de produto");
                    Console.Write("Nome: ");
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

                } catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                } catch (FormatException)
                {
                    Console.WriteLine("Digite um valor válido.");
                }
            }
        }
    }
}
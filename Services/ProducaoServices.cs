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
                    Console.WriteLine("Cadastro de produto");
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
                    
                } catch
                {
                    
                }
            }
        }
    }
}
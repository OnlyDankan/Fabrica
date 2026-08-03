using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Data;


namespace Fabrica.Services
{
    public class FabricaService
    {
        private List<> fabricas = new List<>();

        public void CadastrarProduto()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Cadastro de produto");
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine() ?? "";

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
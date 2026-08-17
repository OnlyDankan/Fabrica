using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Data;
using Fabrica.Models;
using System.Diagnostics;



namespace Fabrica.Services
{
    public class FabricaService
    {
        private List<Produto> produtos = new List<Produto>(); 
        private List<MateriaPrima> materias = new List<MateriaPrima>(); //unificar essa list com a de produtos.
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
                    Console.Write("Sua resposta: ");
        
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
                break;
            }
        }





        public void Listagens()
        {
            Console.WriteLine("=== LISTAGENS ====");

            Console.Clear();

            while (true) {
            
                Console.WriteLine("\n1 - Produtos");
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
        }



            public void Atualizar()
        {
            Console.Clear();
            
            while (true)
            {
                try
                {
                 Console.WriteLine("O que você deseja atualziar?");
                 Console.WriteLine("\n1 - Produtos");
                 Console.WriteLine("2 - Matéria-Prima");
                 Console.Write("Digite sua resposta: ");

                if (int.TryParse(Console.ReadLine(), out int opcaoAtt)) {
                 
                 Console.Clear();

                 switch (opcaoAtt)
                    {
                        case 1:
                            Console.WriteLine("Qual você deseja alterar?");
                            Console.WriteLine("\n1 - Nome");
                            Console.WriteLine("2 - ID"); 
                            int produtoAtt = int.Parse(Console.ReadLine() ?? "");

                            Console.Clear();

                           switch (produtoAtt)
                            {
                                case 1:
                                    Console.Write("Digite o ID do produto que você deseja alterar: ");
                                    int idProd = int.Parse(Console.ReadLine() ?? "");
                                    Produto? IDproduto = produtos.FirstOrDefault(p => p.ID == idProd);

                                     if (IDproduto == null)
                                    {
                                        Console.WriteLine("Produto não encontrado. Tente novamente.");
                                        return; 
                                    } 

                                    Console.Clear();

                                    Console.Write("Novo nome: ");
                                    string nomeAtt = Console.ReadLine() ?? "";

                                    if (string.IsNullOrWhiteSpace(nomeAtt))
                                    {
                                      throw new ArgumentException("O nome não pode ser vazio");            
                                    }

                                    bool nomeExiste = produtos.Any(p => p.Nome == nomeAtt && p != IDproduto);
                                    
                                    if (nomeExiste)
                                    {
                                       throw new ArgumentException("Nome já existe. Tente novamente.");
                                                  
                                    }
                                    IDproduto.Nome = nomeAtt;
                                    Console.WriteLine("Nome atualizado com sucesso!");
                                break;


                                case 2:
                                    Console.Write("Digite o ID do produto que você deseja alterar: ");
                                    string prodId = Console.ReadLine() ?? "";
                                    //Produto? idProduto = produtos.FirstOrDefault(p => p.Nome == );

                                    if (!int.TryParse(prodId, out int novoID))
                                    {
                                      throw new ArgumentException("ID inválido. Tente novamente");
                                    }

                                    Console.Clear();

                                    Console.Write("Novo ID: ");
                                    int idAtt = int.Parse(Console.ReadLine() ?? "");

                                    if (int.IsNegative(idAtt))
                                    {
                                      throw new ArgumentException("Número inválido. Tente novamente");            
                                    }

                                    novoID = idAtt; //eu acho que ta errado isso aqui
                                    Console.WriteLine("ID atualizado com sucesso!");
                                    
                                    
                                break;
                           
                            }                            
                        break;

                     case 2:
                         Console.WriteLine("Qual você deseja alterar?");
                         Console.WriteLine("\n 1 - ID");
                         Console.WriteLine("2 - Nome");
                         Console.WriteLine("3 - Quantidade");
                         int materiaAtt = int.Parse(Console.ReadLine() ?? "");

                            switch (materiaAtt)
                              {
                                case 1:
                                    Console.Write("Digite o ID do produto que você deseja alterar: ");
                                    int idMate = int.Parse(Console.ReadLine() ?? "");
                                    MateriaPrima? materiasEncontrada = materias.FirstOrDefault(m => m.ID == idMate);

                                    if (materiasEncontrada == null)
                                        {
                                          Console.WriteLine("Item não encontrado. Tente novamente.");      
                                          return;      
                                        }

                                        Console.Clear();

                                        Console.Write("Novo ID: ");
                                        int idATT = int.Parse(Console.ReadLine() ?? "");

                                        if (int.IsNegative(idATT))
                                        {
                                            throw new ArgumentException("O ID não pode ser negativo.");
                                        }

                                        materiasEncontrada.ID = idATT;
                                        Console.WriteLine("ID atualizado com sucesso!");
                                    return;    


                                    case 2:
                                        Console.Write("Digite o ID da Materia-Prima que você deseja alterar: ");
                                        int idMateria = int.Parse(Console.ReadLine() ?? "");
                                        MateriaPrima? materiaNome = materias.FirstOrDefault(m => m.ID == idMateria);

                                        if (materiaNome == null)
                                        {
                                            Console.WriteLine("Matéria-Prima não encontrada. Tente novamente.");
                                            return;
                                        }

                                        Console.Clear();

                                        Console.Write("Novo nome: ");
                                        string novoNomeMate = Console.ReadLine() ?? "";

                                        if (string.IsNullOrWhiteSpace(novoNomeMate))
                                        {
                                            throw new ArgumentException("O nome não pode ser vazio.");
                                        }

                                        bool nomeMateExiste = materias.Any(m => m.Nome == novoNomeMate && m.ID != idMateria);

                                        if (nomeMateExiste)
                                        {
                                            throw new ArgumentException("Nome já existente. Tente novamente.");
                                        }

                                        materiaNome.Nome = novoNomeMate;
                                        Console.WriteLine("Nome atualizado com sucesso!");
                                    return;


                                    case 3:
                                        Console.Write("Digite o ID da Materia-Prima que você deseja alterar: ");
                                        int MateriaBusca = int.Parse(Console.ReadLine() ?? "");
                                        MateriaPrima? novaMateria = materias.FirstOrDefault(m => m.ID == MateriaBusca);

                                         if (novaMateria == null)
                                         {
                                            Console.WriteLine("Matéria-Prima não encontrada. Tente novamente.");
                                            return;
                                         }

                                        Console.Clear();

                                        Console.Write("Nova Quantidade: ");
                                        int quantidadeMateria = int.Parse(Console.ReadLine() ?? "");
                                        
                                        if (int.IsNegative(quantidadeMateria))
                                        {
                                            throw new ArgumentException("A quantidade não pode ser negativa. Tente novamente.");
                                        }

                                        novaMateria.Quantidade = quantidadeMateria;
                                        Console.WriteLine("Quantidade atualizada com sucesso!");
                                    return;
                                }
                        break;
                    }

                  }
                } catch
                {
                    
                }
            }
        }



    }
}
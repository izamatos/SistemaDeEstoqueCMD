using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace GestorDeEstoque
{
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("===================");
                Console.WriteLine("SISTEMA DE ESTOQUE");
                Console.WriteLine("===================");
                Console.WriteLine("1 - Listar\n2 - Adicionar Produto\n3 - Remover Produto\n4 - Registrar Entrada\n5 - Registrar Saida\n6 - Sair");

                string opçao = Console.ReadLine();
                int opint = int.Parse(opçao);

                if (opint > 0 && opint < 7)
                {
                    Menu escolha = (Menu)opint;

                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }

                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }

            
        }
        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos");
            int i = 0;
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Console.WriteLine("Entrada registrada!");
                Salvar();
            }
        }


        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto que quer remover: ");
            int id = int.Parse(Console.ReadLine());
            if(id >=0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que quer dar baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Console.WriteLine("Entrada registrada!");
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.WriteLine("1 - Produto Fisico\n2 - Ebook\n3 - Curso");
            string opstr = Console.ReadLine();
            int escolhaint = int.Parse(opstr);

            switch(escolhaint)
            {
                case 1:
                    CadastrarPfisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break; 
                case 3:
                    CadastrarCurso();
                    break;
            }


        }

        static void CadastrarPfisico()
        {
            Console.WriteLine("Cadastrando Produto Físico:");
            Console.WriteLine("Nome ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preço = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preço, frete);
            produtos.Add(pf);
            Salvar();

        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook:");
            Console.WriteLine("Nome ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preço = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook (nome, preço, autor);
            produtos.Add(eb);
            Salvar();
            
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso:");
            Console.WriteLine("Nome ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preço = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preço, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                
                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }



    }

}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{

    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preço, string autor)
        {
            this.nome = nome;
            this.preço = preço;
            this.autor = autor;

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada em estoque de Ebooks");
            Console.ReadLine();
        }


        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas do ebook {nome}");
            Console.WriteLine("Digite a quantidade de vendas: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Registrado");
            Console.ReadLine();
        }

        public void Exibir()
        {

            Console.WriteLine($"Nome do Ebook: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço do Ebook: {preço}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("=================================");
        }

    }

}


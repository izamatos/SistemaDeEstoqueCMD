using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preço, string autor)
        {
            this.nome = nome;
            this.preço = preço;
            this.autor = autor;

        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas do curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }


        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Registrado");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do curso: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço do curso: {preço}");
            Console.WriteLine($"Vagas disponiveis: {vagas}");
            Console.WriteLine("=================================");
        }
    }

}
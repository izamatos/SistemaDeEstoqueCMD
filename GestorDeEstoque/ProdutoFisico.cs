using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeEstoque
{

    [System.Serializable]
    class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preço, float frete)
        {
            this.nome = nome;
            this.preço = preço;
            this.frete = frete;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que vai dar baixa: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Registrado");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preço}");
            Console.WriteLine($"Qt em Estoque: {estoque}");
            Console.WriteLine("=================================");
        }
    }


}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace ColeçãoMagic
{
    class Program
    {
        private static List<string> Opções = new List<string>
        {
            "0 - Sair do programa.",
            "1 - Adicionar cartas à sua coleção.",
            "2 - Imprimir a sua coleção."
        };
        
        static void Main(string[] args)
        {
            var coleção = new ColeçãoMagic();
            Console.WriteLine("Bem-vindo ao collection builder de Magic. Escolha uma das opções:");
            while (true)
            {
                ImprmirOpções();
                var opção = LerOpção();
                RealizarAção(opção, coleção);
                if (opção == OpçõesMenu.Sair)
                {
                    Console.WriteLine("Saindo do programa.");
                    break;
                }
            }
        }

        private static OpçõesMenu LerOpção()
        {
            string opçãoEscolhidaString = Console.ReadLine();
            bool opçãoÉVálida = Enum.TryParse(opçãoEscolhidaString, out OpçõesMenu opçãoEscolhida);
            if (!opçãoÉVálida)
            {
                return OpçõesMenu.Inválida;
            }
            else return opçãoEscolhida;
        }

        private static void ImprmirOpções()
        {
            foreach (var opção in Opções)
            {
                Console.WriteLine(opção);
            }
        }

        private static void RealizarAção(OpçõesMenu opção, ColeçãoMagic coleção)
        {
            switch (opção)
            {
                case OpçõesMenu.Sair:
                    break;
                case OpçõesMenu.AdicionarCartas:
                    AdicionarCartas(coleção);
                    break;
                case OpçõesMenu.ImprimirColeção:
                    ImprimirColeção(coleção);
                    break;
                case OpçõesMenu.Inválida:
                    break;
                default:
                    break;
            }
        }

        private static void AdicionarCartas(ColeçãoMagic coleção)
        {
            Console.WriteLine("Você optou por adicionar uma carta. Qual o nome da carta a ser adicionada:");
            string carta = Console.ReadLine();
            bool foiInserida = coleção.AdicionarCarta(carta);
            if (foiInserida)
            {
                Console.WriteLine("Carta adicionada à sua coleção.");
            }
            else
            {
                Console.WriteLine("A sua coleção já possui esta carta.");
            }
        }

        private static void ImprimirColeção(ColeçãoMagic coleção)
        {
            if (coleção.EstáVazia())
            {
                Console.WriteLine("Sua lista está vazia no momento.");
            }
            else
            {
                Console.WriteLine("Sua lista atual contém as seguintes cartas:");
                Console.WriteLine(coleção.FormaImpressa());
            }
        }
    }
}

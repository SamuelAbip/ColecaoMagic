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
        private static List<string> Cartas = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao collection builder de Magic. Escolha uma das opções:");
            while (true)
            {
                ImprmirOpções();
                OpçõesMenu opção = LerOpção();
                RealizarAção(opção);
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

        private static void RealizarAção(OpçõesMenu opção)
        {
            switch (opção)
            {
                case OpçõesMenu.Sair:
                    break;
                case OpçõesMenu.AdicionarCartas:
                    AdicionarCartas();
                    break;
                case OpçõesMenu.ImprimirColeção:
                    ImprimirColeção();
                    break;
                case OpçõesMenu.Inválida:
                    break;
                default:
                    break;
            }
        }

        private static void AdicionarCartas()
        {
            string carta = LerCarta();
            if (!Cartas.Contains(carta))
            {
                Cartas.Add(carta);
                Console.WriteLine("Carta adicionada à sua coleção.");
            }
            else
            {
                Console.WriteLine("A sua coleção já possui esta carta.");
            }
        }

        private static string LerCarta()
        {
            Console.WriteLine("Você optou por adicionar uma carta. Qual o nome da carta a ser adicionada:");
            string cartaDigitada = Console.ReadLine();
            return FormatarNomeCarta(cartaDigitada);
        }

        private static string FormatarNomeCarta(string cartaDigitada)
        {
            string[] formatandoCarta = cartaDigitada.Split(" ");
            List<string> acumuladorString = new List<string>();
            foreach (string palavra in formatandoCarta)
            {
                string nomeFormatado = palavra.Substring(0, 1).ToUpper() + palavra.Substring(1).ToLower();
                acumuladorString.Add(nomeFormatado);
            }
            string cartaAdicionada = string.Join(" ", acumuladorString);
            return cartaAdicionada;
        }

        private static void ImprimirColeção()
        {
            bool checaConteúdoLista = Cartas.Any();
            if (!checaConteúdoLista)
            {
                Console.WriteLine("Sua lista está vazia no momento.");
            }
            else
            {
                Console.WriteLine("Sua lista atual contém as seguintes cartas:");
                foreach (string carta in Cartas)
                {
                    Console.WriteLine(carta);
                }
            }
        }
    }
}

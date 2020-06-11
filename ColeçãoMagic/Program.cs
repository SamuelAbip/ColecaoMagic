using System;
using System.Collections.Generic;

namespace ColeçãoMagic
{
    class Program
    {
        private static List<string> Cartas = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao collection builder de Magic. Escolha uma das opções:");
            while (true)
            {
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
            Console.WriteLine("0 - Sair do programa.");
            Console.WriteLine("1 - Adicionar cartas à sua coleção.");
            Console.WriteLine("2 - Imprimir a sua coleção.");
            string opçãoEscolhidaString = Console.ReadLine();
            bool opçãoÉVálida = Enum.TryParse(opçãoEscolhidaString, out OpçõesMenu opçãoEscolhida);
            if (!opçãoÉVálida)
            {
                return OpçõesMenu.Inválida;
            }
            else return opçãoEscolhida;
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
            throw new NotImplementedException();
        }

        private static void ImprimirColeção()
        {
            throw new NotImplementedException();
        }
    }

    public enum OpçõesMenu
    {
        Sair = 0,
        AdicionarCartas = 1,
        ImprimirColeção = 2,
        Inválida = 99
    }
}

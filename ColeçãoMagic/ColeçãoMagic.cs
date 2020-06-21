using System.Collections.Generic;

namespace ColeçãoMagic
{
    public class ColeçãoMagic
    {
        private List<string> Cartas = new List<string>();

        public bool AdicionarCarta(string nomeCarta)
        {
            string nomeFormatado = FormatarNomeCarta(nomeCarta);
            if (!Cartas.Contains(nomeFormatado))
            {
                Cartas.Add(nomeFormatado);
                return true;
            }
            else
            {
                return false;
            }
        }

        private string FormatarNomeCarta(string cartaDigitada)
        {
            string[] formatandoCarta = cartaDigitada.Split(" ");
            var acumuladorString = new List<string>();
            foreach (string palavra in formatandoCarta)
            {
                string nomeFormatado = palavra.Substring(0, 1).ToUpper() + palavra.Substring(1).ToLower();
                acumuladorString.Add(nomeFormatado);
            }
            string cartaAdicionada = string.Join(" ", acumuladorString);
            return cartaAdicionada;
        }

        public string FormaImpressa()
        {
            var listagemNomes = new List<string>();
            foreach (var itemNaLista in Cartas)
            {
                listagemNomes.Add(itemNaLista);
            }
            string cartasEmString = string.Join("\n", listagemNomes);
            return cartasEmString;
        }

        public bool EstáVazia()
        {
            bool coleçãoVazia = !Cartas.Any();
            if (coleçãoVazia)
            {
                return true;
            }
            else return false;
        }
    }
}

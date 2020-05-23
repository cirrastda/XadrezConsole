using Jogo.Tabuleiro;
using System;
using XadrezConsole.Xadrez.Exceptions;

namespace XadrezConsole.Xadrez.Posicoes
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = char.ToUpper(coluna);
            Linha = linha;
        }

        public PosicaoXadrez(string posicao)
        {
            if (posicao.Length != 2) throw new PosicaoXadrezException("Posição Inválida");
            try
            {
                Coluna = char.ToUpper(posicao[0]);
                Linha = int.Parse(posicao[1].ToString());
            } catch(Exception e)
            {
                throw new PosicaoXadrezException("Posição Inválida");
            }
        }

        public Posicao ToPosicao()
        {
            Posicao p = new Posicao(8 - Linha, ((int)char.ToUpper(Coluna)) - 65 );
            return p;
        }

        public override string ToString()
        {
            return ""+Coluna+Linha;
        }
    }
}

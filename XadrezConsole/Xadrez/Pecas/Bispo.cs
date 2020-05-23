using Jogo.Tabuleiro;
using System.Collections.Generic;
using System.Linq;

namespace XadrezConsole.Xadrez.Pecas
{
    class Bispo: PecaXadrez
    {

        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }


        public override List<Posicao> PosicoesPossiveis()
        {

            List<Posicao> posicoesPossiveis = new List<Posicao>();
            posicoesPossiveis.AddRange(Diagonais());

            return posicoesPossiveis;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}

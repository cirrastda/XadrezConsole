using Jogo.Tabuleiro;
using System.Collections.Generic;
using System.Linq;

namespace XadrezConsole.Xadrez.Pecas
{
    class Rainha: PecaXadrez
    {

        public Rainha(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override List<Posicao> PosicoesPossiveis()
        {

            List<Posicao> posicoesPossiveis = new List<Posicao>();
            posicoesPossiveis.AddRange(Diagonais());
            posicoesPossiveis.AddRange(Horizontais());
            posicoesPossiveis.AddRange(Verticais());

            return posicoesPossiveis;
        }


        public override string ToString()
        {
            return "D";
        }
    }
}

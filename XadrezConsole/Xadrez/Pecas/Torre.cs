
using Jogo.Tabuleiro;
using System.Collections.Generic;
using System.Linq;

namespace XadrezConsole.Xadrez.Pecas
{
    class Torre: PecaXadrez
    {

        public Torre(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor, partida)
        {

        }

        public override List<Posicao> PosicoesPossiveis()
        {
            List<Posicao> posicoesPossiveis = new List<Posicao>();
            posicoesPossiveis.AddRange(Verticais());
            posicoesPossiveis.AddRange(Horizontais());
            return posicoesPossiveis;
        }


        public override string ToString()
        {
            return "T";
        }
    }
}

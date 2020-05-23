
using Jogo.Tabuleiro;
using System.Collections.Generic;

namespace XadrezConsole.Xadrez.Pecas
{
    class Cavalo: PecaXadrez
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }
        public override List<Posicao> PosicoesPossiveis()
        {
            List<Posicao> posicoesPossiveis = new List<Posicao>();

            posicoesPossiveis.Add(new Posicao(Posicao.Linha - 2, Posicao.Coluna - 1));
            posicoesPossiveis.Add(new Posicao(Posicao.Linha - 2, Posicao.Coluna + 1));

            posicoesPossiveis.Add(new Posicao(Posicao.Linha - 1, Posicao.Coluna - 2));
            posicoesPossiveis.Add(new Posicao(Posicao.Linha - 1, Posicao.Coluna + 2));

            posicoesPossiveis.Add(new Posicao(Posicao.Linha + 1, Posicao.Coluna - 2));
            posicoesPossiveis.Add(new Posicao(Posicao.Linha + 1, Posicao.Coluna + 2));

            posicoesPossiveis.Add(new Posicao(Posicao.Linha + 2, Posicao.Coluna - 1));
            posicoesPossiveis.Add(new Posicao(Posicao.Linha + 2, Posicao.Coluna + 1));

            return posicoesPossiveis;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}

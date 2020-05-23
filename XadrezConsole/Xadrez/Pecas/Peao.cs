
using Jogo.Tabuleiro;
using System.Collections.Generic;
using System.Linq;

namespace XadrezConsole.Xadrez.Pecas
{
    class Peao: PecaXadrez
    {

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor, partida)
        {

        }

        private bool _verificaPosicaoEnPassant(Posicao p)
        {
            
            if ((Tabuleiro.PosicaoValida(p)) &&
                (Tabuleiro.PosicaoOcupadaAdversario(p, Cor)) &&
                (Tabuleiro.Peca(p) == Partida.PecaVulneravelEnPassant)) {
                return true;
            }
            return false;

        }
        private Posicao _enPassant()
        {
            if (Cor == Cor.Branco && Posicao.Linha != 3) return null;
            if (Cor == Cor.Preto && Posicao.Linha != 4) return null;

            if (_verificaPosicaoEnPassant(new Posicao(Posicao.Linha, Posicao.Coluna - 1))) return new Posicao((Cor == Cor.Branco ? Posicao.Linha - 1 : Posicao.Linha + 1), Posicao.Coluna - 1);
            if (_verificaPosicaoEnPassant(new Posicao(Posicao.Linha, Posicao.Coluna + 1))) return new Posicao((Cor == Cor.Branco ? Posicao.Linha - 1 : Posicao.Linha + 1), Posicao.Coluna + 1);

            return null;
        }
        public override List<Posicao> PosicoesPossiveis()
        {

            List<Posicao> posicoesPossiveis = new List<Posicao>();

            if (Cor == Cor.Branco)
            {
                if (!Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha - 1, Posicao.Coluna), Cor))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha - 1, Posicao.Coluna));
                }
                if (Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha - 1, Posicao.Coluna - 1), Cor))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha - 1, Posicao.Coluna - 1));
                }
                if (Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha - 1, Posicao.Coluna + 1), Cor))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha - 1, Posicao.Coluna + 1));
                }
                if (QtdeMovimentos == 0)
                {
                    if (!Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha - 2, Posicao.Coluna), Cor))
                    {
                        posicoesPossiveis.Add(new Posicao(Posicao.Linha - 2, Posicao.Coluna));
                    }
                }
            } else
            {
                if (!Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha + 1, Posicao.Coluna), Cor))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha + 1, Posicao.Coluna));
                }
                if (Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha + 1, Posicao.Coluna - 1), Cor))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha + 1, Posicao.Coluna - 1));
                }
                if (Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha + 1, Posicao.Coluna + 1), Cor))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha + 1, Posicao.Coluna + 1));
                }

                if (QtdeMovimentos == 0)
                {
                    if (!Tabuleiro.PosicaoOcupadaAdversario(new Posicao(Posicao.Linha + 2, Posicao.Coluna), Cor))
                    {
                        posicoesPossiveis.Add(new Posicao(Posicao.Linha + 2, Posicao.Coluna));
                    }
                }
            }
            Posicao pEnPassant = _enPassant();
            if (pEnPassant != null) posicoesPossiveis.Add(pEnPassant);
            return posicoesPossiveis;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}

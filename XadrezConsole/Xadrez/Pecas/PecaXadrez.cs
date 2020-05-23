using Jogo.Tabuleiro;
using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Xadrez.Pecas
{
    abstract class PecaXadrez : Peca
    {
        protected PartidaDeXadrez Partida { get; set; }

        public PecaXadrez(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
            //this.Partida = partida;
        }
        public PecaXadrez(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.Partida = partida;
        }
        protected List<Posicao> Diagonais()
        {
            List<Posicao> posicoesPossiveis = new List<Posicao>();
            Posicao pLinha;
            int i = 0;
            for (int linha = Posicao.Linha - 1; linha >= 0; linha--)
            {
                i++;
                pLinha = new Posicao(linha, Posicao.Coluna - i);
                if (Tabuleiro.PosicaoValida(pLinha))
                {
                    posicoesPossiveis.Add(pLinha);
                } else
                {
                    break;
                }
                if (CheckPararMovimento(pLinha)) break;
            }
            i = 0;
            for (int linha = Posicao.Linha - 1; linha >= 0; linha--)
            {
                i++;
                pLinha = new Posicao(linha, Posicao.Coluna + i);
                if (Tabuleiro.PosicaoValida(pLinha))
                {
                    posicoesPossiveis.Add(pLinha);
                }
                else
                {
                    break;
                }
                if (CheckPararMovimento(pLinha)) break;
            }
            i = 0;
            for (int linha = Posicao.Linha + 1; linha < Tabuleiro.Linhas; linha++)
            {
                i++;
                pLinha = new Posicao(linha, Posicao.Coluna - i);
                if (Tabuleiro.PosicaoValida(pLinha))
                {
                    posicoesPossiveis.Add(pLinha);
                }
                else
                {
                    break;
                }
                if (CheckPararMovimento(pLinha)) break;
            }
            i = 0;
            for (int linha = Posicao.Linha + 1; linha < Tabuleiro.Linhas; linha++)
            {
                i++;
                pLinha = new Posicao(linha, Posicao.Coluna + i);
                if (Tabuleiro.PosicaoValida(pLinha))
                {
                    posicoesPossiveis.Add(pLinha);
                }
                else
                {
                    break;
                }
                if (CheckPararMovimento(pLinha)) break;
            }

            return posicoesPossiveis;
        }

        public List<Posicao> Horizontais()
        {
            List<Posicao> posicoesPossiveis = new List<Posicao>();
            Posicao pLinha;
            for (int coluna = Posicao.Coluna - 1; coluna >= 0 ; coluna--)
            {
                pLinha = new Posicao(Posicao.Linha, coluna);
                if (Tabuleiro.PosicaoValida(pLinha)) posicoesPossiveis.Add(pLinha);
                if (CheckPararMovimento(pLinha)) break;
            }

            for (int coluna = Posicao.Coluna + 1; coluna < Tabuleiro.Colunas; coluna++)
            {
                pLinha = new Posicao(Posicao.Linha, coluna);
                if (Tabuleiro.PosicaoValida(pLinha)) posicoesPossiveis.Add(pLinha);
                if (CheckPararMovimento(pLinha)) break;
            }

            return posicoesPossiveis;
        }

        public List<Posicao> Verticais()
        {
            List<Posicao> posicoesPossiveis = new List<Posicao>();
            Posicao pLinha;
            for (int linha = Posicao.Linha - 1; linha >= 0; linha--)
            {
                pLinha = new Posicao(linha, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pLinha)) posicoesPossiveis.Add(pLinha);
                if (CheckPararMovimento(pLinha)) break;
            }
            for (int linha = Posicao.Linha + 1; linha < Tabuleiro.Colunas; linha++)
            {
                pLinha = new Posicao(linha, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pLinha)) posicoesPossiveis.Add(pLinha);
                if (CheckPararMovimento(pLinha)) break;
            }
            return posicoesPossiveis;
        }

        public abstract override List<Posicao> PosicoesPossiveis();
    }
}

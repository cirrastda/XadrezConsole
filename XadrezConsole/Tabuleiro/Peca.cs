using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jogo.Tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }

        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QtdeMovimentos = 0;
        }

        public void Mover(Posicao novaPosicao, bool reverte = false)
        {
            Posicao = novaPosicao;
            if (reverte)
            {
                QtdeMovimentos--;
            } else
            {
                QtdeMovimentos++;
            }
            
        }

        protected bool CheckPosicaoAtual(Posicao novaPosicao)
        {
            return ((novaPosicao.Linha == Posicao.Linha) && (novaPosicao.Coluna == Posicao.Coluna));
        }

        protected bool CheckMovimento(Posicao p)
        {
            Peca peca = Tabuleiro.Peca(p);
            return (peca == null || (peca.Cor != this.Cor));
        }

        public bool CheckPararMovimento(Posicao p)
        {
            Peca peca = Tabuleiro.Peca(p);
            return (!(peca == null));
        }

        public abstract List<Posicao> PosicoesPossiveis();

        public bool[,] MovimentosPossiveis()
        {
            List<Posicao> posicoes = this.PosicoesPossiveis();
            bool[,] tmpPos = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            foreach (Posicao p in posicoes)
            {
                if (Tabuleiro.PosicaoValida(p) && CheckMovimento(p))
                {
                    tmpPos[p.Linha, p.Coluna] = true;
                }
            }

            return tmpPos;
        }

        public bool PodeMoverPara(Posicao p)
        {
            return (MovimentosPossiveis()[p.Linha, p.Coluna] == true);
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] tmpPos = MovimentosPossiveis();
            for(int i = 0; i< tmpPos.GetLength(0);i++)
            {
                for (int j = 0; j<tmpPos.GetLength(1); j++)
                {
                    if (tmpPos[i, j] == true) return true;
                }
                
            }

            return false;
        }

    }
}
 
using Jogo.Tabuleiro.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }


        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public void AdicionarPeca(Peca peca, Posicao pos)
        {
            if (PosicaoOcupada(pos)) throw new TabuleiroException($"Já existe uma peça na posicao ({pos.Linha},{pos.Coluna})");
            Pecas[pos.Linha, pos.Coluna] = peca;
            peca.Posicao = pos;
        }

        public Peca RemoverPeca(Posicao pos)
        {
            if (Peca(pos) == null) return null;
            
            Peca p = Peca(pos);
            p.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return p;
        }

        public Peca MoverPeca(Posicao origem, Posicao destino, bool reverteMovimento = false)
        {
            Peca p = RemoverPeca(origem);
            AdicionarPeca(p, destino);
            p.Mover(destino, reverteMovimento);

            return p;
        }

        private bool PosicaoOcupada(Posicao pos)
        {
            ValidarPosicao(pos);
            return (Peca(pos) != null);
        }

        public bool PosicaoOcupadaAdversario(Posicao pos, Cor cor)
        {
            if (!PosicaoValida(pos)) return false;

            Peca p = Peca(pos);
            if (p == null) return false;
            return (p.Cor != cor);
        }

        public bool PosicaoValida(Posicao pos)
        {
            bool ret = (pos.Linha >= 0 && pos.Linha < Linhas);
            ret = ret && (pos.Coluna >= 0 && pos.Coluna < Colunas);
            return ret;
        }

        private void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos)) throw new TabuleiroException($"Posição Inválida ({pos.Linha},{pos.Coluna})");
        }

        /*
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < Linhas; i++)
            {
                
                builder.Append(8 - i);
                for (int j = 0; j < Colunas; j++)
                {
                    Peca p = Peca(i, j);
                    builder.Append(" ").Append(p==null ?"-":p.ToString());
                }
                builder.AppendLine();
            }
            builder.Append("  ");
            for (int j = 0; j < Colunas; j++)
            {
                builder.Append((char)(65 + j)).Append(" ");
                //builder.Append(j+1).Append(" ");
            }
            builder.AppendLine();
            return builder.ToString();
        }
        */
    }
}

using Jogo.Tabuleiro;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;

namespace XadrezConsole.Xadrez.Pecas
{
    class Rei: PecaXadrez
    {

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor, partida)
        {

        }

        private bool _checkTorreRoque(Posicao p)
        {
            Peca peca = Partida.Tabuleiro.Peca(p);
            if (peca == null) return false;
            if (!(peca is Torre) ) return false;
            if (peca.Cor != Cor) return false;

            if (peca.QtdeMovimentos > 0) return false;

            return true;
        }

        private bool _checkEspacosVaziosRoque(Posicao posTorre)
        {
            Posicao origem, destino;
            if (posTorre.Coluna > Posicao.Coluna) {
                origem = Posicao;
                destino = posTorre;
            } else
            {
                origem = posTorre;
                destino = Posicao;
            }
            for (int i = origem.Coluna + 1; i < destino.Coluna; i++)
            {
                Peca peca = Partida.Tabuleiro.Peca(new Posicao(Posicao.Linha, i));
                if (peca != null) return false;
            }
            return true;
        }

        public override List<Posicao> PosicoesPossiveis()
        {
            List<Posicao> posicoesPossiveis = new List<Posicao>();
            for (int linha = Posicao.Linha - 1; linha <= Posicao.Linha + 1; linha ++ )
            {
                for (int coluna = Posicao.Coluna - 1; coluna <= Posicao.Coluna + 1; coluna ++ )
                {
                    if (!this.CheckPosicaoAtual(new Posicao(linha,coluna))) {
                        posicoesPossiveis.Add(new Posicao(linha, coluna));
                    }
                }
            }
            
            // #JogadaEspecial Roque Pequeno
            if (QtdeMovimentos == 0 && !Partida.Xeque)
            {
                Posicao pTorre = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (_checkTorreRoque(pTorre) && _checkEspacosVaziosRoque(pTorre))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha, Posicao.Coluna + 2));
                }
            }

            // #JogadaEspecial Roque Grande
            if (QtdeMovimentos == 0 && !Partida.Xeque)
            {
                Posicao pTorre = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (_checkTorreRoque(pTorre) && _checkEspacosVaziosRoque(pTorre))
                {
                    posicoesPossiveis.Add(new Posicao(Posicao.Linha, Posicao.Coluna - 2));
                }
            }
            return posicoesPossiveis;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}

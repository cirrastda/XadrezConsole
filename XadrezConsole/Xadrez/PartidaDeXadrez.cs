using Jogo.Tabuleiro;
using Jogo.Tabuleiro.Exception;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using XadrezConsole.Xadrez.Exceptions;
using XadrezConsole.Xadrez.Pecas;
using XadrezConsole.Xadrez.Posicoes;

namespace XadrezConsole.Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }

        public bool Terminada { get; private set; }
        public Peca PecaVulneravelEnPassant { get; private set; } = null;

        public bool Xeque { get; set; }

        private HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;

        

        public PartidaDeXadrez()
        {
            this.Tabuleiro = new Tabuleiro(8,8);
            this.Turno = 1;
            this.JogadorAtual = Cor.Branco;
            this.Terminada = false;
            this._pecas = new HashSet<Peca>();
            this._capturadas = new HashSet<Peca>();

            this.PecaVulneravelEnPassant = null;

            this.IniciarJogo();
        }


        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            IEnumerable<Peca> where = _capturadas.Where(item => item.Cor == cor);

            return where.ToHashSet();
        }
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            IEnumerable<Peca> where = _pecas.Where(item => item.Cor == cor);

            HashSet<Peca> emJogo = where.ToHashSet();

            emJogo.ExceptWith(PecasCapturadas(cor));

            return emJogo;
        }

        private Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = Tabuleiro.RemoverPeca(destino);
            if (pecaCapturada!=null)
            {
                _capturadas.Add(pecaCapturada);
            }
            Peca p = Tabuleiro.MoverPeca(origem, destino);

            // #JogadaEspecial Roque Pequeno
            if ((p is Rei) && (destino.Coluna == origem.Coluna + 2))
            {
                Tabuleiro.MoverPeca(new Posicao(origem.Linha, origem.Coluna + 3), new Posicao(origem.Linha, origem.Coluna + 1));
            }
            // #JogadaEspecial Roque Grande
            if ((p is Rei) && (destino.Coluna == origem.Coluna - 2))
            {
                Tabuleiro.MoverPeca(new Posicao(origem.Linha, origem.Coluna - 4), new Posicao(origem.Linha, origem.Coluna - 1));
            }
            // #JogadaEspecial EnPassant
            if ((p is Peao) && (destino.Coluna != origem.Coluna) && (pecaCapturada==null) ) 
            {
                pecaCapturada = PecaVulneravelEnPassant;
                Tabuleiro.RemoverPeca(PecaVulneravelEnPassant.Posicao);
                _capturadas.Add(pecaCapturada);
            }
            // #JogadaEspecial Promocao
            if ((p is Peao) && ( ((p.Cor==Cor.Branco) && (destino.Linha == 0)) || ((p.Cor == Cor.Preto) && (destino.Linha == Tabuleiro.Linhas - 1)) )) {
                Rainha novaRainha = new Rainha(Tabuleiro, p.Cor);
                _pecas.Remove(p);
                Tabuleiro.TrocarPeca(destino, novaRainha);
                _pecas.Add(novaRainha);
            }

            return pecaCapturada;
        }

        private void ReverteMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.MoverPeca(destino, origem, true);
            if (pecaCapturada != null) {
                _capturadas.Remove(pecaCapturada);
                // #JogadaEspecial EnPassant
                if ((p is Peao) && (destino.Coluna != origem.Coluna) && (pecaCapturada == PecaVulneravelEnPassant))
                {
                    Posicao nPos = new Posicao((pecaCapturada.Cor == Cor.Branco ? destino.Linha - 1 : destino.Linha + 1), destino.Coluna);
                    Tabuleiro.AdicionarPeca(pecaCapturada, nPos);
                } else
                {
                    Tabuleiro.AdicionarPeca(pecaCapturada, destino);
                }                
            }
            // #JogadaEspecial Roque Pequeno
            if ((p is Rei) && (destino.Coluna == origem.Coluna + 2))
            {
                Tabuleiro.MoverPeca(new Posicao(origem.Linha, origem.Coluna + 1), new Posicao(origem.Linha, origem.Coluna + 3), true);
            }
            // #JogadaEspecial Roque Grande
            if ((p is Rei) && (destino.Coluna == origem.Coluna - 2))
            {
                Tabuleiro.MoverPeca(new Posicao(origem.Linha, origem.Coluna - 1), new Posicao(origem.Linha, origem.Coluna - 4), true);
            }


        }

        private void _verificaVulnerabilidadeEnPassant(Peca p, Posicao origem, Posicao destino)
        {
            if ((p is Peao) &&
                    ((p.Cor == Cor.Preto && (destino.Linha == origem.Linha + 2)) ||
                    (p.Cor == Cor.Branco && (destino.Linha == origem.Linha - 2)))
                ) {
                PecaVulneravelEnPassant = p;
            } else
            {
                PecaVulneravelEnPassant = null;
            }
            
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (ReiEmCheque(JogadorAtual))
            {
                ReverteMovimento(origem, destino, pecaCapturada);
                throw new AutoXequeException();
            }

            Xeque = (ReiEmCheque(Adversario(JogadorAtual)));
            if (ReiEmChequeMate(Adversario(JogadorAtual)))
            {
                Terminada = true;
            } else
            {
                Turno++;
                MudaJogador();
            }

            // #JogadaEspecialEnPassant
            _verificaVulnerabilidadeEnPassant(Tabuleiro.Peca(destino), origem, destino);

        }

        private Cor Adversario(Cor cor)
        {
            return (cor == Cor.Preto ? Cor.Branco : Cor.Preto);
        }

        private Peca Rei(Cor cor)
        {
            foreach(Peca p in PecasEmJogo(cor))
            {
                if (p is Rei) return p;
            }
            return null;
        }

        public bool MovimentosPossiveisParaPosicao(Cor cor, Posicao pos)
        {
            foreach (Peca p in PecasEmJogo(cor))
            {
                if (p.PodeMoverPara(pos)) return true;
            }
            return false;
        }


        public bool ReiEmCheque(Cor cor)
        {
            Rei r = (Rei)Rei(cor);
            if (r == null) throw new SemReiException(cor);
            if (MovimentosPossiveisParaPosicao(Adversario(cor), Rei(cor).Posicao)) return true;
            return false;
        }


        private bool TestaMovimentoXeque(Peca p, Cor cor, Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            bool retorno = false;
            if (ReiEmCheque(cor))
            {                                          
                retorno = true;
            }
            ReverteMovimento(origem, destino, pecaCapturada);
            return retorno;
        }

        private bool MovimentosPecaEmXeque(Peca p)
        {
            bool[,] movimentos = p.MovimentosPossiveis();
            bool ret = true;
            for(int i = 0; i<movimentos.GetLength(0);i++)
            {
                for (int j = 0; j < movimentos.GetLength(1); j++)
                {
                    if (movimentos[i, j]) ret = ret && TestaMovimentoXeque(p, p.Cor, p.Posicao, new Posicao(i, j));
                    if (ret == false) break;
                }
            }
            return ret;
        }

        public bool ReiEmChequeMate(Cor cor)
        {
            if (!ReiEmCheque(cor)) return false;
            foreach (Peca p in PecasEmJogo(cor))
            {
                if (!MovimentosPecaEmXeque(p)) return false;
            }
            return true;
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tabuleiro.Peca(pos)==null) throw new TabuleiroException("Não existe Peça na Posição Selecionada");
            if (JogadorAtual != Tabuleiro.Peca(pos).Cor) throw new GameException("A Peça Selecionada não é sua");

            if (!Tabuleiro.Peca(pos).ExisteMovimentosPossiveis()) throw new GameException("A peça não possui movimentos possíveis a serem realizados");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            Peca pOrigem = Tabuleiro.Peca(origem);
            if (!pOrigem.PodeMoverPara(destino)) throw new MovimentoIndevidoException("A peça selecionada não pode ser movida para esta posição.");
        }

        private void MudaJogador()
        {
            this.JogadorAtual = (this.JogadorAtual == Cor.Branco ? Cor.Preto : Cor.Branco);
        }

        private void IniciarJogo()
        {
            this.IniciarPecas(Cor.Branco);
            this.IniciarPecas(Cor.Preto);
        }

        private void AdicionarPeca(Peca p, int linha, int coluna)
        {
            Tabuleiro.AdicionarPeca(p, new Posicao(linha, coluna));
            _pecas.Add(p);
        }

        private void IniciarPecas(Cor cor)
        {
            int linhaPecas = 0;
            int linhaPeoes = 0;
            int colunaRei = 0;
            int colunaRainha = 0;
            switch (cor)
            {
                case Cor.Branco:
                    linhaPecas = 7;
                    linhaPeoes = 6;
                    //colunaRei = 3;
                    //colunaRainha = 4;
                    colunaRei = 4;
                    colunaRainha = 3;
                    break;
                case Cor.Preto:
                    linhaPecas = 0;
                    linhaPeoes = 1;
                    colunaRei = 4;
                    colunaRainha = 3;
                    break;
                default:
                    throw new CorException("Cor da Peça Inválida");
            }

            AdicionarPeca(new Torre(Tabuleiro, cor, this), linhaPecas, 0);
            AdicionarPeca(new Torre(Tabuleiro, cor, this), linhaPecas, 7);
            AdicionarPeca(new Cavalo(Tabuleiro, cor), linhaPecas, 1);
            AdicionarPeca(new Cavalo(Tabuleiro, cor), linhaPecas, 6);
            AdicionarPeca(new Bispo(Tabuleiro, cor), linhaPecas, 2);
            AdicionarPeca(new Bispo(Tabuleiro, cor), linhaPecas, 5);
            AdicionarPeca(new Rei(Tabuleiro, cor, this), linhaPecas, colunaRei);
            AdicionarPeca(new Rainha(Tabuleiro, cor), linhaPecas, colunaRainha);

            for (int i = 0; i <= 7; i++) AdicionarPeca(new Peao(Tabuleiro, cor, this), linhaPeoes, i);
        }

    }
}

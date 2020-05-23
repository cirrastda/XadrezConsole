using System;
using System.Collections.Generic;
using System.Text;
using XadrezConsole.Xadrez.Posicoes;

namespace XadrezConsole.Xadrez
{
    class MovimentoXadrez
    {
        public PosicaoXadrez Origem { get; set; }
        public PosicaoXadrez Destino { get; set; }

        public MovimentoXadrez(PosicaoXadrez origem, PosicaoXadrez destino)
        {
            Origem = origem;
            Destino = destino;
        }
        public MovimentoXadrez(string origem, string destino)
        {
            Origem = new PosicaoXadrez(origem);
            Destino = new PosicaoXadrez(destino);
        }
    }
}

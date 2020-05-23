using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Xadrez.Exceptions
{
    class SemReiException: ApplicationException
    {

        public SemReiException(Jogo.Tabuleiro.Cor cor) : base("Não existe um Rei da cor " + cor.ToString() + " no tabuleiro") {}
    }
}

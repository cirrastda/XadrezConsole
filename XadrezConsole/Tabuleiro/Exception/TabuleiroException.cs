using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Tabuleiro.Exception
{
    class TabuleiroException: ApplicationException
    {
        public TabuleiroException(String mensagem) : base(mensagem) { }

    }
}

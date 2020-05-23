using System;
using System.Collections.Generic;
using System.Text;

namespace Jogo.Tabuleiro.Exception
{
    class CorException: ApplicationException
    {

        public CorException(String mensagem): base(mensagem) { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Xadrez.Exceptions
{
    class PosicaoXadrezException : ApplicationException
    {
        public PosicaoXadrezException(String mensagem) : base(mensagem) { }
    }
}

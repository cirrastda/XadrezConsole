using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Xadrez.Exceptions
{
    class GameException : ApplicationException
    {
        public GameException(String mensagem) : base(mensagem) { }
    }
}

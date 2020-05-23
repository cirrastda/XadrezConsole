using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Xadrez.Exceptions
{
    class MovimentoIndevidoException: GameException
    {
        public MovimentoIndevidoException(String mensagem) : base(mensagem) { }
    }
}

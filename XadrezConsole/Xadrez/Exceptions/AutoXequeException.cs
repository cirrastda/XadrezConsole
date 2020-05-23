using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Xadrez.Exceptions
{
    class AutoXequeException: GameException
    {
        public AutoXequeException() : base("Você não pode colocar o seu rei em Cheque. Deve fazer outro movimento") { }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Exceptions
{
    class MethodException: ApplicationException
    {
        public MethodException() : base("O método não existe") { }
    }
}

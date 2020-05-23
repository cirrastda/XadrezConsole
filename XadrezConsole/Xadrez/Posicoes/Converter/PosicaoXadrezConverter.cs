using System;
using System.Collections.Generic;
using System.Text;
using XadrezConsole.Xadrez.Posicoes.Validator;

namespace XadrezConsole.Xadrez.Posicoes.Converter
{
    static class PosicaoXadrezConverter
    {
        static public PosicaoXadrez Convert(String pos)
        {
            if (!PosicaoXadrezValidator.Validate(pos)) return null;
            return new PosicaoXadrez(pos[0], int.Parse(char.ToString(pos[1]) ) );
        }
    }
}

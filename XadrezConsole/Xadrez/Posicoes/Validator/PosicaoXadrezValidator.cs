using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace XadrezConsole.Xadrez.Posicoes.Validator
{
    static class PosicaoXadrezValidator
    {
        static public bool Validate(string posicao)
        {
            posicao = posicao.ToUpper();
            if (posicao.Length != 2) return false;
            if (!ValidateColumn(posicao[0])) return false;
            if (!ValidateLine(posicao[1])) return false;

            return true;
        }

        static private bool ValidateColumn(char valor)
        {
            char val;
            if (!char.TryParse(char.ToString(valor), out val)) return false;

            int ascii = (int)val;
            
            if (ascii < 65 || ascii > 72) return false;

            return true;
        }

        static private bool ValidateLine(char valor)
        {
            int val;
            if (!int.TryParse(char.ToString(valor), out val)) return false;

            if (val < 1 || val > 8) return false;
            
            return true;
        }
    }
}

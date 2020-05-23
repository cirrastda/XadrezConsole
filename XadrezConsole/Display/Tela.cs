using System;
using System.Collections.Generic;
using System.Text;
using Jogo.Tabuleiro;
using Jogo.Tabuleiro.Exception;
using XadrezConsole.Xadrez;
using XadrezConsole.Xadrez.Posicoes;
using XadrezConsole.Xadrez.Posicoes.Converter;

namespace XadrezConsole.Display
{
    static class Tela
    {
    
        public static void ImprimirTabuleiro(Tabuleiro t)
        {
            //System.Console.WriteLine(t);
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < t.Linhas; i++)
            {

                Console.Write(8-i);
                for (int j = 0; j < t.Colunas; j++)
                {
                    ImprimePeca(t.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int j = 0; j < t.Colunas; j++)
            {
                Console.Write((char)(65 + j));
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void ImprimirTabuleiro(Tabuleiro t, bool[,] posicoesPossiveis)
        {
            //System.Console.WriteLine(t);
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < t.Linhas; i++)
            {

                Console.Write(8 - i);
                for (int j = 0; j < t.Colunas; j++)
                {
                    Console.BackgroundColor = (posicoesPossiveis[i, j] ? fundoAlterado : fundoOriginal);
                    ImprimePeca(t.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int j = 0; j < t.Colunas; j++)
            {
                Console.Write((char)(65 + j));
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        private static void ImprimePeca(Peca p)
        {
            Console.Write(" ");
            if (p == null)
            {
                Console.Write("-");
            }
            else
            {
                switch (p.Cor)
                {
                    case Cor.Branco:
                        Console.Write(p);
                        break;
                    case Cor.Preto:
                        ConsoleColor color = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(p);
                        Console.ForegroundColor = color;
                        break;
                    default:
                        throw new CorException("Cor Inválida");
                }
            }
        }

        
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();

            while (PosicaoXadrezConverter.Convert(s)==null)
            {
                Console.WriteLine("Posicao Inválida");
                s = Console.ReadLine();
            }

            return PosicaoXadrezConverter.Convert(s);
        }


        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);

            Console.WriteLine();
            ImprimirPecasCapturadas(partida);

            Console.WriteLine("Turno: " + partida.Turno);

            Console.WriteLine("Aguardando Jogada: " + partida.JogadorAtual);

            if (partida.Xeque)
            {
                Console.WriteLine("VOCÊ ESTÁ EM XEQUE!");
            }


        }

        public static void ImprimeCheckMate(PartidaDeXadrez partida)
        {
            Console.WriteLine("XEQUEMATE!");
            Console.WriteLine("O vencedor é: " + partida.JogadorAtual);
        }

        private static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas: ");
            foreach(Cor c in Enum.GetValues(typeof(Cor)))
            {

                ConsoleColor color = Console.ForegroundColor;
                if (c == Cor.Preto) Console.ForegroundColor = ConsoleColor.Yellow;
                
                Console.Write(c.ToString()+": ");
                ImprimirConjunto(partida.PecasCapturadas(c));
                
                Console.ForegroundColor = color;
            }
            Console.WriteLine();
        }

        private static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            foreach (Peca p in conjunto) builder.Append(p).Append(", ");
            builder.Append("]");
            Console.WriteLine(builder.ToString());
        }
    }
}

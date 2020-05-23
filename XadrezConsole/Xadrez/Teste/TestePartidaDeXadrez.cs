using System;
using System.Collections.Generic;
using System.Text;

namespace XadrezConsole.Xadrez.Teste
{
    static class TestePartidaDeXadrez
    {
        static public List<MovimentoXadrez> TesteXequeMate()
        {
            List<MovimentoXadrez> movimentos = new List<MovimentoXadrez>();
            movimentos.Add(new MovimentoXadrez("e2", "e4"));
            movimentos.Add(new MovimentoXadrez("e7", "e5"));
            movimentos.Add(new MovimentoXadrez("f1", "c4"));
            movimentos.Add(new MovimentoXadrez("b8", "c6"));
            movimentos.Add(new MovimentoXadrez("d1", "h5"));
            movimentos.Add(new MovimentoXadrez("g8", "f6"));
            movimentos.Add(new MovimentoXadrez("h5", "f7"));
            return movimentos;
        }

        static public List<MovimentoXadrez> TesteRoquePequeno()
        {
            List<MovimentoXadrez> movimentos = new List<MovimentoXadrez>();
            movimentos.Add(new MovimentoXadrez("e2", "e4"));
            movimentos.Add(new MovimentoXadrez("a7", "a6"));
            movimentos.Add(new MovimentoXadrez("f1", "a6"));
            movimentos.Add(new MovimentoXadrez("b7", "a6"));
            movimentos.Add(new MovimentoXadrez("g1", "h3"));
            movimentos.Add(new MovimentoXadrez("a6", "a5"));
            movimentos.Add(new MovimentoXadrez("e1", "g1"));
            return movimentos;
        }

        static public List<MovimentoXadrez> TesteRoqueGrande()
        {
            List<MovimentoXadrez> movimentos = new List<MovimentoXadrez>();
            movimentos.Add(new MovimentoXadrez("d2", "d4"));
            movimentos.Add(new MovimentoXadrez("a7", "a5"));
            movimentos.Add(new MovimentoXadrez("c1", "g5"));
            movimentos.Add(new MovimentoXadrez("a5", "a4"));
            movimentos.Add(new MovimentoXadrez("d1", "d3"));
            movimentos.Add(new MovimentoXadrez("a8", "a5"));
            movimentos.Add(new MovimentoXadrez("b1", "a3"));
            movimentos.Add(new MovimentoXadrez("b8", "c6"));
            movimentos.Add(new MovimentoXadrez("e1", "c1"));
            return movimentos;
        }

        static public List<MovimentoXadrez> TesteEnPassant()
        {
            List<MovimentoXadrez> movimentos = new List<MovimentoXadrez>();
            movimentos.Add(new MovimentoXadrez("e2", "e4"));
            movimentos.Add(new MovimentoXadrez("b7", "b5"));
            movimentos.Add(new MovimentoXadrez("e4", "e5"));
            movimentos.Add(new MovimentoXadrez("d7", "d5"));
            movimentos.Add(new MovimentoXadrez("e5", "d6"));
            movimentos.Add(new MovimentoXadrez("b5", "b4"));
            movimentos.Add(new MovimentoXadrez("c2", "c4"));
            movimentos.Add(new MovimentoXadrez("b4", "c3"));
            return movimentos;
        }



    }
}

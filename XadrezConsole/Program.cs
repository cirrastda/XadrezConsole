using System;
using System.Diagnostics.CodeAnalysis;
using Jogo.Tabuleiro;
using Jogo.Tabuleiro.Exception;
using XadrezConsole.Xadrez;
using XadrezConsole.Display;
using XadrezConsole.Xadrez.Exceptions;
using System.Security.Cryptography;
using XadrezConsole.Xadrez.Posicoes;
using System.Collections.Generic;
using XadrezConsole.Xadrez.Teste;
using System.Linq;
using System.Threading;
using System.Reflection;
using XadrezConsole.Exceptions;

namespace XadrezConsole
{
    class Program
    {
        static private bool _teste = false;

        private static List<MovimentoXadrez> _getTeste(string[] args)
        {
            List<MovimentoXadrez> movimentosTeste = new List<MovimentoXadrez>();

            if (args[0] == "teste") _teste = true;
            
            string funcao = args[1];
            
            if (_teste)
            {
                MethodInfo method = typeof(TestePartidaDeXadrez).GetMethod(funcao);
                if (method == null) throw new MethodException();

                //movimentosTeste = TestePartidaDeXadrez.TesteXequeMate();
                movimentosTeste = (List<MovimentoXadrez>)method.Invoke(null,null);
            }

            return movimentosTeste;
        }

        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                
                List<MovimentoXadrez> movimentosTeste = _getTeste(args);
                
                while (!partida.Terminada)
                {
                    try
                    {
                        Posicao origem, destino;
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        if (_teste)
                        {
                            if (movimentosTeste.ElementAtOrDefault(partida.Turno-1)!=null)
                            {
                                origem = movimentosTeste[partida.Turno - 1].Origem.ToPosicao();
                                Console.WriteLine(movimentosTeste[partida.Turno - 1].Origem.ToString());
                                Thread.Sleep(500);
                            } else
                            {
                                origem = Tela.LerPosicaoXadrez().ToPosicao();
                            }
                        } else
                        {
                            origem = Tela.LerPosicaoXadrez().ToPosicao();
                        }
                        
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tabuleiro.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);


                        Console.Write("Destino: ");
                        if (_teste)
                        {
                            if (movimentosTeste.ElementAtOrDefault(partida.Turno - 1) != null)
                            {
                                destino = movimentosTeste[partida.Turno - 1].Destino.ToPosicao();
                                Console.WriteLine(movimentosTeste[partida.Turno - 1].Destino.ToString());
                                Thread.Sleep(500);
                            }
                            else
                            {
                                destino = Tela.LerPosicaoXadrez().ToPosicao();
                            }
                        }
                        else
                        {
                            destino = Tela.LerPosicaoXadrez().ToPosicao();
                        }
                        

                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (GameException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }catch(SemReiException e)
                    {
                        Console.WriteLine("Erro Fatal no Jogo: " + e.Message);
                        Console.ReadLine();
                        Environment.Exit(1);
                    }
                }
                Tela.ImprimeCheckMate(partida);
                Console.ReadLine();
                //PosicaoXadrez pos = new PosicaoXadrez('A', 1);
                //Console.WriteLine(pos.ToPosicao());
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Erro ao Iniciar Jogo: "+e.Message);
            }
        }






    }
}

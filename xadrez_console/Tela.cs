﻿using JogoXadrez;
using tabuleiro;

namespace xadrez_console {
    internal class Tela {

        public static void imprimirTabuleiro(Tabuleiro tabuleiro) {

            for (int i = 0; i < tabuleiro.Linha; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Coluna; j++) {
                    Tela.imprimirPeca(tabuleiro.Peca(i, j));
                    Console.Write("");                  
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tabuleiro, bool[,] possicoesPossiveis) {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.White;

            for (int i = 0; i < tabuleiro.Linha; i++) {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < tabuleiro.Coluna; j++) {
                    if (possicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    Tela.imprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez() {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse($"{s[1]}");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca) {
            if (peca == null) {
                Console.Write("- ");
            } else {
                if (peca.Cor == Cor.Branca)
                    Console.Write(peca);
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
            }
                
        }
    }
}
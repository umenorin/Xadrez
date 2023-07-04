﻿using System;
using tabuleiro;

namespace xadrez_console {
    internal class Tela {

        public static void imprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.Linha; i++) {
                for (int j = 0; j < tabuleiro.Coluna; j++) {
                    if (tabuleiro.Peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    Console.Write(tabuleiro.Peca(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
using JogoXadrez;
using tabuleiro;

namespace xadrez_console {
    internal class Tela {

        public static void ImprimirPartida(PartidaDeXadrez partida) {
            imprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine("\nTurno: " + partida.Turno);
            
            if (!partida.Terminada) {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                if (partida.Xeque) {
                    Console.Write("Xeque!!");
                }
            } else {
                Console.WriteLine("XequeMate");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }


            
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida) {

            Console.WriteLine("Pecas capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.Write("\nPretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto) {
            Console.Write("[");
            foreach(Peca p in conjunto) {
                Console.Write($"{p} ");
            }
            Console.Write("]");
        }

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
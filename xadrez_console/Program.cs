using tabuleiro;
using xadrez_console;
using JogoXadrez;
using tabuleiro.Exception;

try {
    PartidaDeXadrez partida = new PartidaDeXadrez();

    while (!partida.Terminada) {
        try {
            Console.Clear();
            Tela.ImprimirPartida(partida);

            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDeOrigem(origem);
            bool[,] posicoesPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.imprimirTabuleiro(partida.Tab, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
            partida.ValidarPosicaoDeDestino(origem, destino);

            partida.RealizaJogada(origem, destino);
        } catch (tabuleiroException e) {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
    Console.Clear();
    Tela.ImprimirPartida(partida);
} catch (tabuleiroException e) {
    Console.WriteLine(e.Message);
}
using tabuleiro;

namespace JogoXadrez {
    internal class PosicaoXadrez {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha) {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao() {
            return new Posicao(8 -  Coluna, 8 - 'a');
        }

        public override string ToString() {
            return $"{Coluna}{Linha}";
        }
    }
}

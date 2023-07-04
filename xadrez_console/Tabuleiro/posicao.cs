
namespace tabuleiro {
    internal class Posicao {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int colina) { 
            Linha = linha;
            Coluna = colina;
        }

        public override string ToString() {
            return $"{Linha} , {Coluna}";
        }
    }
}

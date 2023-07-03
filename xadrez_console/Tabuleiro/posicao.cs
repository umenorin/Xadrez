
namespace Tabuleiro {
    internal class posicao {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public posicao(int linha, int colina) { 
            Linha = linha;
            Coluna = colina;
        }

        public override string ToString() {
            return $"{Linha} , {Coluna}";
        }
    }
}

using System;
using tabuleiro;

namespace tabuleiro {
    abstract class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca( Cor cor, Tabuleiro tab) { 
            Posicao = null;
            Cor = cor;
            QteMovimentos = 0;
            Tabuleiro = tab;
        }
        public void IncrementarQteMovimentos() {
            QteMovimentos++;
        }

        public void DecrementarQteMovimentos() {
            QteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for(int i=0; i<Tabuleiro.Linha; i++) {
                for(int j=0; j<Tabuleiro.Coluna; j++) {
                    if (mat[i, j])
                        return true;
                }
            }
            return false;
        }
        public bool MovimentoPossivel(Posicao pos) {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}

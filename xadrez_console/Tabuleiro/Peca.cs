using System;
using tabuleiro;

namespace tabuleiro {
    internal class Peca {
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
    }
}

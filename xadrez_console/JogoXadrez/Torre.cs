﻿using tabuleiro;

namespace JogoXadrez {
    internal class Torre : Peca {
        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab) {

        }

        public bool PodeMover(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.Linha, Tabuleiro.Coluna];
            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha , Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor) {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            return mat;
        }

        public override string ToString() {
            return "T ";
        }
    }
}

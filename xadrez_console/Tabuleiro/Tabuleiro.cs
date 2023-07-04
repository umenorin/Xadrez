using System;
using Tabuleiro.Exception;

namespace tabuleiro {
    internal class Tabuleiro {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linha, int coluna) {
            Linha = linha;
            Coluna = coluna;
            Pecas = new Peca[ Linha,Coluna ];
        }

        public Peca Peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }

        public  Peca Peca(Posicao pos) {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool existePeca(Posicao pos) {
            if (existePeca(pos))
                throw new tabuleiroException("ja existe uma peca nessa posicao");
            validarPosicao(pos);
            return Peca(pos) != null;
        }

        public void colocarPeca(Peca p, Posicao pos) {
            Pecas[pos.Linha,pos.Coluna] = p;
            p.Posicao = pos;
        }

        public bool posicaoValida(Posicao pos) {
            if(pos.Linha < 0|| pos.Linha>=Linha|| pos.Coluna<0 || pos.Coluna>=Coluna) 
                return false;
            return true;
        }
        public void validarPosicao(Posicao pos) {
            if (!posicaoValida(pos))
                throw new tabuleiroException("Posicao invalida");
        }
    }
}

using tabuleiro;

namespace JogoXadrez {
    internal class Rei: Peca {
        private PartidaDeXadrez Partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) :base(cor, tab) {
            Partida = partida;
        }
        private PartidaDeXadrez partida;

        public override string ToString() {
            return "R ";
        }

        public bool PodeMover(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public bool TesteTorreRoque(Posicao pos) {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor == Cor && p is Torre && p.QteMovimentos == 0;
        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tabuleiro.Linha, Tabuleiro.Coluna];
            Posicao pos =new Posicao(0,0);

            //Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Diagonal direita superior
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Diagonal direita inferior
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Diagonal esquerda inferior
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Diagonal esquerda superior
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // Metodo roque pequeno
            if(QteMovimentos == 0 && !Partida.Xeque) {
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if(TesteTorreRoque(posT1)) {
                    Posicao P1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao P2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tabuleiro.Peca(P1) == null && Tabuleiro.Peca(P2) == null) {
                        mat[Posicao.Linha,Posicao.Coluna + 2] = true;
                    }
                }
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna -4);
                if (TesteTorreRoque(posT2)) {
                    Posicao P1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao P2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao P3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tabuleiro.Peca(P1) == null && Tabuleiro.Peca(P2) == null && Tabuleiro.Peca(P3) == null) {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}

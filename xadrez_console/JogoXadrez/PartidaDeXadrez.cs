using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using tabuleiro.Exception;

namespace JogoXadrez {
    internal class PartidaDeXadrez {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; set; }
        public Cor JogadorAtual { get; set; }
        public bool Terminada { get; set; }
        public bool Xeque {get; private set;}
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        

        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            Terminada = false;
        }
        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);

            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual)) {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new tabuleiroException("voce nao pode se colocar em xeque");
            }
            if (EstaEmXeque(Adversaria(JogadorAtual)))
                Xeque = true;
            else 
                Xeque = false;
            Turno++;
            MudarJogador();
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQteMovimentos();
            if(pecaCapturada != null) {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void ValidarPosicaoDeOrigem(Posicao pos) {
            if (Tab.Peca(pos) == null)
                throw new tabuleiroException("Nao existe peca na posicao escolhida");

            if(JogadorAtual!=Tab.Peca(pos).Cor)
                throw new tabuleiroException("A peca de origem nao e sua");

            if(!Tab.Peca(pos).ExisteMovimentosPossiveis())
                throw new tabuleiroException("nao ha movimentos possiveis para a peca escolhida");
        }
        public void ValidarPosicaoDeDestino(Posicao origem, Posicao Destino) {
            if(!Tab.Peca(origem).PodeMoverParaPosicao(Destino))
                throw new tabuleiroException("Posicao de destino invalida");
        }

        public void MudarJogador() {
            if (JogadorAtual == Cor.Branca)
                JogadorAtual = Cor.Preta;
            else
                JogadorAtual = Cor.Branca;
        }

        public void ColocarNovaPeca(char coluna, int linha,Peca peca) {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca p in capturadas) {
                if(p.Cor == cor) 
                    aux.Add(p);
                
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca p in pecas) {
                if (p.Cor == cor) {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor) {
            if (cor == Cor.Branca)
                return Cor.Preta;
            else
                return Cor.Branca;
        }

        private Peca rei(Cor cor) {
            foreach(Peca p in PecasEmJogo(cor)) {
                if (p is Rei)
                    return p;
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null)
                throw new tabuleiroException("nao tem rei da cor " + cor + " no tabuleiro");

            foreach (Peca p in PecasEmJogo(Adversaria(cor))) {
                bool[,] mat = p.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                    return true;

            }

                return false;
        }



        private void ColocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
        }
    }
}

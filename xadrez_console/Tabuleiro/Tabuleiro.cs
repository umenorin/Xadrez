﻿using System;
using tabuleiro.Exception;

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

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos) {
            if (ExistePeca(pos)) {
                throw new tabuleiroException("Ja existe uma peca nesta posicao");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos) {
            if (Peca(pos) == null)
                return null;
            Peca aux = Peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos) {
            if(pos.Linha < 0|| pos.Linha>=Linha|| pos.Coluna<0 || pos.Coluna>=Coluna) 
                return false;
            return true;
        }
        public void ValidarPosicao(Posicao pos) {
            if (!PosicaoValida(pos))
                throw new tabuleiroException("Posicao invalida");
        }
    }
}

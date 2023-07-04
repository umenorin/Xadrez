﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace xadrez_console.Tabuleiro {
    internal class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Posicao posicao, Cor cor,int qteMovimentos, Tabuleiro tabuleiro) { 
            Posicao = posicao;
            Cor = cor;
            QteMovimentos = qteMovimentos;
            Tabuleiro = tabuleiro;
        }
    }
}

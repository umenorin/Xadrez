using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro.Exception {
    internal class tabuleiroException : ApplicationException {

        public tabuleiroException(string message) : base(message) {
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Acompanhamento
    {
        public string acompanhamento { get; private set; }
        public int qntd { get; private set; }
        public Acompanhamento(string acompanhamento, int qntd) {
            this.acompanhamento = acompanhamento;
            this.qntd = qntd;
        }
    }
}

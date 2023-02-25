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
        public int id_dispensa { get; private set; }
        public Acompanhamento(string acompanhamento, int qntd, int id_dispensa) {
            this.acompanhamento = acompanhamento;
            this.qntd = qntd;
            this.id_dispensa = id_dispensa;
        }
    }
}

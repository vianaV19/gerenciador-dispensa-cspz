using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lanche
    {
        public string lanche { get; private set; }
        public string turno { get; private set; }
        public int qntd { get; private set; }
   

        public Lanche(string lanche, string turno, int qntd) {
            this.lanche = lanche;
            this.turno = turno;
            this.qntd = qntd; 
 
        }
    }
}

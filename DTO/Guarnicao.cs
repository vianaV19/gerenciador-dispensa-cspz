using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Guarnicao
    {
        public string guarnicao { private set; get; }
        public int qntd { private set; get; }
        public int id_dispensa { private set; get; }
        public Guarnicao(string guarnicao, int qntd, int id_dispensa)
        {
            this.guarnicao = guarnicao;
            this.qntd = qntd;
            this.id_dispensa = id_dispensa;
        }
    }
}

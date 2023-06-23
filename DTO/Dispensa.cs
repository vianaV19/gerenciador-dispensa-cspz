using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Dispensa
    {
        public int assist { private set; get; }
        public int projet { private set; get; }
        public int colab { private set; get; }
        public int total { private set; get; }
        public string proteina { private set; get; }
        public int proteinaQntd { private set; get; }
        public string sobremesa { private set; get; }
        public int sobremesaQntd { private set; get; }

        public Dispensa(int assist, int projet, int colab, int total)
        {
            this.assist = assist;
            this.projet = projet;
            this.colab = colab;
            this.total = total;
        }

        public Dispensa(int assist, int projet, int colab, int total, string proteina, int proteinaQntd, string sobremesa, int sobremesaQntd) {
            this.assist = assist;
            this.projet = projet;
            this.colab = colab;
            this.total = total;
            this.proteina = proteina;
            this.proteinaQntd = proteinaQntd;
            this.sobremesa = sobremesa;
            this.sobremesaQntd = sobremesaQntd;
        }
    }
}

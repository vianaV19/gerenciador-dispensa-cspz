using DAL;
using DTO;
using MySql.Data.MySqlClient;
using System;

namespace BLL
{
 
    public class DispensaBLL : CentroBLL
    {
        public void cadastrar(Dispensa d) {
            string query = "insert into tb_dispensa " +
              "( assist, colab, total, proteina, qntd_proteina, sobremesa, qntd_sobremesa) " +
              "values " +
              "( @assist, @colab, @total, @proteina, @qntd_proteina, @sobremesa, @qntd_sobremesa)";

            MySqlCommand cmd = new MySqlCommand(query);

            cmd.Parameters.Add("@assist", MySqlDbType.UInt32).Value = Convert.ToInt32(d.assist);
            cmd.Parameters.Add("@colab", MySqlDbType.UInt32).Value = Convert.ToInt32(d.colab);
            cmd.Parameters.Add("@total", MySqlDbType.UInt32).Value = Convert.ToInt32(d.total);
            cmd.Parameters.Add("@proteina", MySqlDbType.String).Value = d.proteina;
            cmd.Parameters.Add("@qntd_proteina", MySqlDbType.Int32).Value = Convert.ToInt32(d.proteinaQntd);
            cmd.Parameters.Add("@sobremesa", MySqlDbType.String).Value = d.sobremesa;
            cmd.Parameters.Add("@qntd_sobremesa", MySqlDbType.UInt32).Value = Convert.ToInt32(d.sobremesaQntd);

            BDAccess.insert(cmd);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;
using MySql.Data.MySqlClient;

namespace BLL
{

    public class CentroBLL 
    {
        public DataSet consulta(string srcTable)
        {
            return BDAccess.RetrieveAll(srcTable, srcTable);
        }

        public DataSet consultaPorData(DateTime data)
        {
            string sqlFormattedDate = data.ToString("yyyy-MM-dd"); 
            string query = "select * from tb_acompanhamento where `data` between '"+ sqlFormattedDate + " 00' and '" +
                sqlFormattedDate + " 23'";

            return BDAccess.Retrieve(query, "tb_acompanhamento");
        }
        public DataSet consultaPorDia(int dia)
        {
            throw new NotImplementedException();
        }

        public DataSet consultaPorMes(int mes)
        {
            throw new NotImplementedException();
        }

        public DataSet consultaComQuery(string query, string srcTable)
        {
            return BDAccess.Retrieve(query, srcTable);
        }

        public void cadastrarDispensa(Dispensa d) {

            string query;
            MySqlCommand cmd;

            if (d.sobremesa == null) {
                query = "insert into tb_dispensa " +
                "( assist, colab, projet, total) " +
                "values " +
                "( @assist, @colab, @projet, @total)";

                cmd = new MySqlCommand(query);

                cmd.Parameters.Add("@assist", MySqlDbType.UInt32).Value = Convert.ToInt32(d.assist);
                cmd.Parameters.Add("@colab", MySqlDbType.UInt32).Value = Convert.ToInt32(d.colab);
                cmd.Parameters.Add("@projet", MySqlDbType.UInt32).Value = Convert.ToInt32(d.projet);
                cmd.Parameters.Add("@total", MySqlDbType.UInt32).Value = Convert.ToInt32(d.total);

            }
            else
            {
                query = "insert into tb_dispensa " +
                "( assist, colab, projet, total, proteina, qntd_proteina, sobremesa, qntd_sobremesa) " +
                "values " +
                "( @assist, @colab, @projet, @total, @proteina, @qntd_proteina, @sobremesa, @qntd_sobremesa)";

           cmd = new MySqlCommand(query);

                cmd.Parameters.Add("@assist", MySqlDbType.UInt32).Value = Convert.ToInt32(d.assist);
                cmd.Parameters.Add("@colab", MySqlDbType.UInt32).Value = Convert.ToInt32(d.colab);
                cmd.Parameters.Add("@projet", MySqlDbType.UInt32).Value = Convert.ToInt32(d.projet);
                cmd.Parameters.Add("@total", MySqlDbType.UInt32).Value = Convert.ToInt32(d.total);
                cmd.Parameters.Add("@proteina", MySqlDbType.String).Value = d.proteina;
                cmd.Parameters.Add("@qntd_proteina", MySqlDbType.Int32).Value = Convert.ToInt32(d.proteinaQntd);
                cmd.Parameters.Add("@sobremesa", MySqlDbType.String).Value = d.sobremesa;
                cmd.Parameters.Add("@qntd_sobremesa", MySqlDbType.UInt32).Value = Convert.ToInt32(d.sobremesaQntd);
            }
   

          

            BDAccess.insert(cmd);
        }

        public void cadastrarAcompanhamento(Acompanhamento[] acomps) {
            foreach (Acompanhamento a in acomps) {

                if (a == null) continue;

                string query = "insert into tb_acompanhamento (acompanhamento, qntd) " +
                    "values " +
                    "(@acomp, @qntd)";

                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.Add("@acomp", MySqlDbType.String).Value = a.acompanhamento;
                cmd.Parameters.Add("@qntd", MySqlDbType.UInt16).Value = Convert.ToInt16(a.qntd);

                BDAccess.insert(cmd);
            }
           
        }

        public void cadastrarGuarnicao(Guarnicao [] guarns)
        {
            foreach (Guarnicao g in guarns)
            {

                if (g == null) continue;

                string query = "insert into tb_guarnicao (guarnicao, qntd) " +
                    "values " +
                    "(@guarn, @qntd)";

                MySqlCommand cmd = new MySqlCommand(query);
                cmd.Parameters.Add("@guarn", MySqlDbType.String).Value = g.guarnicao;
                cmd.Parameters.Add("@qntd", MySqlDbType.UInt16).Value = Convert.ToInt16(g.qntd);

                BDAccess.insert(cmd);
            }
        }

        public void cadastrarLanche(Lanche l) {
            string query = "insert into tb_lanche (lanche, turno,qntd) " +
                 "values " +
                 "(@lanche, @turno, @qntd)";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.Add("@lanche", MySqlDbType.String).Value = l.lanche;
            cmd.Parameters.Add("@turno", MySqlDbType.String).Value = l.turno;
            cmd.Parameters.Add("@qntd", MySqlDbType.UInt16).Value = Convert.ToInt16(l.qntd);

            BDAccess.insert(cmd);
        }


    }
}

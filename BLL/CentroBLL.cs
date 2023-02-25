using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{

    public class CentroBLL : ICRUD
    {
        public DataSet consulta(string srcTable)
        {
            return BDAccess.RetrieveAll(srcTable, srcTable);
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
       
    }
}

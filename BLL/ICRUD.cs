using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace BLL
{
    internal interface ICRUD
    {
        DataSet consulta(string srcTable);
        DataSet consultaComQuery(string query, string srcTable);
        DataSet consultaPorDia(int dia);
        DataSet consultaPorMes(int mes);

       
    }
}

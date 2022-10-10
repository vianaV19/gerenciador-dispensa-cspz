using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    using MySql.Data.MySqlClient;
    internal class BDAccess
    {
        private static MySqlConnection conn = BDConnection.getInstance().GetConnection();
        public static DataSet ExecuteNonQuery(string query, string srcTable)
        {
            DataSet dataSet = new DataSet();
            MySqlDataAdapter cmd = new MySqlDataAdapter(query, conn);
            cmd.Fill(dataSet, srcTable);

            return dataSet;
        }
    }
}

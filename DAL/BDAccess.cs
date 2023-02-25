using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    using MySql.Data.MySqlClient;

    public class BDAccess
    {
        private static MySqlConnection conn = BDConnection.getInstance().GetConnection();
        public static DataSet Retrieve(string query, string srcTable)
        {
            DataSet dataSet = new DataSet();
            MySqlDataAdapter cmd = new MySqlDataAdapter(query, conn);
            cmd.Fill(dataSet, srcTable);

            cmd.Dispose();

            return dataSet;
        }

        public static DataSet RetrieveAll(string table, string srcTable)
        {
            DataSet dataSet = new DataSet();
            MySqlDataAdapter cmd = new MySqlDataAdapter("select * from " + table, conn);
            cmd.Fill(dataSet, srcTable);

            cmd.Dispose();

            return dataSet;
        }

        public static void insert(MySqlCommand cmd)
        {
            cmd.Connection = conn;

            cmd.ExecuteNonQuery();
        }

        public static void update(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        public static void remove(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
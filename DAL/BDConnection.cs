using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{

    using MySql.Data.MySqlClient;
    internal class BDConnection
    {

        private static BDConnection instance;
        private string _conexaoMySQL = "server=localhost;user id=root;password='';database=cspz;convert zero datetime=True"; 
        private BDConnection() { }

        public static BDConnection getInstance()
        {
            if (instance == null)
            {
                instance = new BDConnection();
            }

            return instance;
        }

        public MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(_conexaoMySQL);

            try
            {
                conn.Open();

                return conn;
            }
            catch 
            {
                return null;
            }

        }
    }
}

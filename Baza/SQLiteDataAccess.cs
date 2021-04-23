using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza
{
    public class SQLiteDataAccess
    {
        public static List<Klub> LoadKlub()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Klub>("select * from Kluby", new DynamicParameters());
                return output.ToList();
            }
        }
        //public static void SaveKlub(Klub klub)
        //{
        //    using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
        //    {
        //        cnn.Execute("insert into Kluby (Nazwa, Ikona, Skrot) values (@Nazwa, NULL, @Skrot)", klub);
        //    }
        //}
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}

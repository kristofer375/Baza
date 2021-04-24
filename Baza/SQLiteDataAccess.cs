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
        public static List<Druzyna> LoadDruzyna(int a)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Druzyna>($"select * from Druzyny where ID_Kluby = { a }", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Zawodnik> LoadZawodnik(int a)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Zawodnik>($"select * from Druzyny where ID_Kluby = { a }", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Test> LoadTestowy(int a)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Test>($"select z.ID, d.Nazwa, k.Numer_Koszulki, z.Nazwisko, z.Imie, p.Pozycja from Zawodnicy as z left join Kadra as k on z.ID=k.ID_Zawodnicy left join Pozycje as p on p.ID=k.Pozycja left join Druzyny as d on k.ID_Druzyny=d.ID where d.ID={ a } order by z.Nazwisko, p.Pozycja <> 'Bramkarz', k.Numer_Koszulki", new DynamicParameters());
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

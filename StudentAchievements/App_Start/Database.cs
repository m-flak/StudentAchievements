using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace StudentAchievements
{
    public class Database
    {
        private readonly DbProviderFactory dbFactory;
        private readonly string connString;

        public Database()
        {
            dbFactory = DbProviderFactories.GetFactory("Npgsql");
            connString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ToString();
        }

        public DbConnection GetConnection()
        {
            var con = dbFactory.CreateConnection();
            con.ConnectionString = this.connString;
            return con;
        }
    }
}

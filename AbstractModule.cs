using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using System.Data.SqlClient;

namespace EcoConception
{
    public abstract class AbstractModule : NancyModule
    {
        public Database Database { get; private set; }
        public abstract IEnumerable<Product> Products { get; }
        public abstract IEnumerable<Category> Categories { get; }

        public AbstractModule()
        {
            /*SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "BDD";
            builder.DataSource = "InstanceAddress";
            builder.UserID = "UserOfTheDatabase";
            Database = new Database(builder);
            Database.OpenConnection();*/
        }
    }
}
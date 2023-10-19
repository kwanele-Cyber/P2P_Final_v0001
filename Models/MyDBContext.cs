using System;
using System.Data.Entity;
using System.Linq;

namespace P2P_Final_v0._001.Models
{
    public class MyDBContext : DbContext
    {
        // Your context has been configured to use a 'MyDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'P2P_Final_v0._001.Models.MyDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyDBContext' 
        // connection string in the application configuration file.
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
using System.Data.Entity;


namespace Ead2Ca1Template.Models
{
    public class MyDatabaseContext : DbContext
    {


        public MyDatabaseContext() : base("name=MyDbConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDatabaseContext>());
        }

        public System.Data.Entity.DbSet<Ead2Ca1Template.Models.Generic> Generics { get; set; }
    }
}

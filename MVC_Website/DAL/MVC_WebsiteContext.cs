using MVC_Website.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace MVC_Website.DAL
{
    public class MVC_WebsiteContext : DbContext
    {
        public MVC_WebsiteContext() : base("MVC_WebsiteContext")
        {
        }


        public DbSet<HelpModel> Help { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
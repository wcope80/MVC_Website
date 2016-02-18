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

       public DbSet<MaxAttempt> MaxAttempts { get; set; }
       public DbSet<Message> Messages { get; set; }
       public DbSet<PhotoGallery> PhotoGalleries { get; set; }
       public DbSet<Gallery> Galleries { get; set; }
    }
}
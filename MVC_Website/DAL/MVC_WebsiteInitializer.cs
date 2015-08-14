using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_Website.Models;

namespace MVC_Website.DAL
{
    public class MVC_WebsiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MVC_WebsiteContext>
    {
        protected override void Seed(MVC_WebsiteContext context)
        {
            var help = new List<HelpModel>
            {
                new HelpModel {Name="Bob Jones",Email="BJones@email.com", Message="This is a test message.", Subject="test"},
                new HelpModel {Name="Tom Smith",Email="TSmith@email.com", Message="This is a test message as well.", Subject="test"}

            };
            help.ForEach(h => context.Help.Add(h));
            context.SaveChanges();

        }

    }
}
namespace Phram.Context.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Phram.Context.PharmContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
        protected override void Seed(Phram.Context.PharmContext context)
        {
            //context.Users.Add(new Pharm.Core.Entities.User
            //{
            //    Password = "5F4DCC3B5AA765D61D8327DEB882CF99",
            //    IsDeleted = false,
            //    IsActive = true,
            //    Email = "oscardybabaphd@gmail.com",
            //    AuthorizationCode = "5F4DCC3B5AA765D61D8327DEB882CF99"
            //});
            //context.SaveChanges();
        }
    }
}

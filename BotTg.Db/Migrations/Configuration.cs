namespace BotTg.Db.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BotTg.Db.DbContextApp>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BotTg.Db.DbContextApp";
        }

        protected override void Seed(BotTg.Db.DbContextApp context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

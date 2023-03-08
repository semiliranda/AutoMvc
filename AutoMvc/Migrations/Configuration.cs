namespace AutoMvc.Migrations
{
    using AutoMvc.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoMvc.Models.AutoDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AutoMvc.Models.AutoDBContext";
        }

        protected override void Seed(AutoMvc.Models.AutoDBContext context)
        {
            context.Autos.AddOrUpdate(i => i.Title,
                new Auto
                {
                    Title = "BMW",
                    Lessee = "Nikolay",
                    Status = "Rented"
                },

                 new Auto
                 {
                     Title = "Mazda ",
                     Lessee = "Sandro",
                     Status = "Rented"
                 },

                 new Auto
                 {
                     Title = "Audi",
                     Lessee = "John",
                     Status = "Rented"
                 },

               new Auto
               {
                   Title = "Opel",
                   Lessee = "",
                   Status = "Free"
               }
           );

        }
    }
}

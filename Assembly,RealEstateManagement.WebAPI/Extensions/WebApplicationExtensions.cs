using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly_RealEstateManagement.WebAPI.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void EnsureDatabaseMigration(this WebApplication application)
        {
            var scope = application.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureDeleted();
                context.Database.Migrate();
                SeedData(context);
            }
            catch (Exception ex) 
            {

            }


        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (context.Managers.Any())
            {
                return;
            }

            var manager = Manager.Create(100, Name.Create("Bruno", new string[] { "Miguel" }, "Roma"), Account.Create("bruno@gmail.com", "12345"),
           Address.Create("Rua x", 5, "1562-958", "Lisboa", "Portugal"), 25, new List<ManagerAllContact>(), new List<ManagerPersonalContact>(),
           new List<Agent>());


            context.Managers.Add(manager);
            context.SaveChanges();
        }

    }
}

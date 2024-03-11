namespace Stajproje
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // optionsBuilder.UseSqlServer("Server=localhost;Database=Personel;Trusted_Connection=True;");
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Personel> Personels { get; set; }

        internal object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }

}

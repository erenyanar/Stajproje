namespace Stajproje
{
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Personel;Trusted_Connection=True;");
        }
        public DbSet<Personel> Personels { get; set; }
    }

}

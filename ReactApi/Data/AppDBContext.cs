using Microsoft.EntityFrameworkCore;

namespace ReactApi.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        //public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        //{

        //}

        //public AppDBContext()
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) =>
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=SLB-BZVF7G3\SQLEXPRESS2012;Initial Catalog=App;Trusted_Connection=True;Connection Timeout=60;");
        //}
    }
}

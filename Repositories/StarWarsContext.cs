using GraphQLNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLNetCore.Data.EntityFramework
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Droid> Droids { get; set; }
    }
}
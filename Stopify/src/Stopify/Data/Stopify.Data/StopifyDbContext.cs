using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stopify.Data.Models;

namespace Stopify.Data
{
    public class StopifyDbContext : IdentityDbContext<StopifyUser, IdentityRole, string>
    {
        DbSet<Product> Products { get; set; }

        public StopifyDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}

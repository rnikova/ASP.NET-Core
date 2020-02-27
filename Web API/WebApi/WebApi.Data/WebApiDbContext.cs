using WebApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class WebApiDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public WebApiDbContext(DbContextOptions options) 
            : base(options)
        {
        }
    }
}
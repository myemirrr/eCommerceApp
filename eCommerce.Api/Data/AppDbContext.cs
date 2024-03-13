using eCommerce.Library.Models;
using Microsoft.EntityFrameworkCore;


namespace eCommerce.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
}
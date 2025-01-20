using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Models;

namespace WebAPI.Data_Access.Database
{
    public class AppDbContext : IdentityDbContext<Models.AppUser, Models.AppRole, string>
    {
        //public DbSet<Models.Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

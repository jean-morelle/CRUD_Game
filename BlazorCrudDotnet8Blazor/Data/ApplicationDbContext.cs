using CRUD_Game.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Game.Data
{
    public class ApplicationDbContext  :DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {
          
        }

        public DbSet <Game> Games { get; set; } 
    }
}

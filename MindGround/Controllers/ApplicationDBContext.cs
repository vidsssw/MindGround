using Microsoft.EntityFrameworkCore;
using MindGround.Models;

namespace MindGround.Controllers
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<MoodBoard> MoodBoard { get; set; }

            
    }
}

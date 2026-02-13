using Microsoft.EntityFrameworkCore;
using UpitiPVC.Models;

namespace UpitiPVC.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}

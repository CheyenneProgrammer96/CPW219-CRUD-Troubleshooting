using CPW219_CRUD_Troubleshooting.Models;
using Microsoft.EntityFrameworkCore;

namespace CPW219_CRUD_Troubleshooting.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using StudentSync.Domain.Students;

namespace StudentSync.Data.Ef.Common;

public class SchoolDbContext:DbContext
{
    public SchoolDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}

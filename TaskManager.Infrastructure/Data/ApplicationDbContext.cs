using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace TaskManager.Infrastructure.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Task> Tasks { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
}
using Microsoft.EntityFrameworkCore;
using Todolist.Models;
namespace Todolist.Data;
public class ApplicationDbContext : DbContext
{
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
    {
    }
    public DbSet<Category> Categories { get; set; }
}

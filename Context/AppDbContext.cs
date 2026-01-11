using Microsoft.EntityFrameworkCore;
using Todos.WebAPI.Models;

namespace Todos.WebAPI.Context;


public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
            
    }
    
    public DbSet<Todo> Todos {get; set; }
}

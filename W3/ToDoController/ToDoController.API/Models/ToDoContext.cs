using Microsoft.EntityFrameworkCore;

namespace ToDoController.API.Models
{
    public class ToDoContext : DbContext
    {
        // constructor
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        // fields
        public DbSet<ToDo> ToDos { get; set; } = null!;
    }
}

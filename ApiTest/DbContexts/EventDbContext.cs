using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.DbContexts
{
    public class EventDbContext : DbContext
    {
        public EventDbContext()
        {
        }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<EventInfo> EventInfo { get; set; }
    }
}

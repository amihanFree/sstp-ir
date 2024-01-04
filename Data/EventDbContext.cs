using Event.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Event.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<GroupProject> GroupProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Group>()
    .HasMany(g => g.GroupUsers)
    .WithOne(gu => gu.ParentGroup)
    .HasForeignKey(gu => gu.GroupId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.GroupProjects)
                .WithOne(gp => gp.ParentGroup)
                .HasForeignKey(gp => gp.GroupId);

        }
    }
}

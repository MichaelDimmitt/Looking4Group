using Looking4Group.Models;
using Microsoft.EntityFrameworkCore;

namespace Looking4Group.Data
{
    public class Looking4GroupContext : DbContext
    {
        public Looking4GroupContext(DbContextOptions<Looking4GroupContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameTag> GameTags { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupTag> GroupTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("User");
            //modelBuilder.Entity<UserTag>().ToTable("UserTag");
            //modelBuilder.Entity<Game>().ToTable("Game");
            //modelBuilder.Entity<GameTag>().ToTable("GameTag");
            //modelBuilder.Entity<Group>().ToTable("Group");
            //modelBuilder.Entity<GroupTag>().ToTable("GroupTag");
        }
    }
}

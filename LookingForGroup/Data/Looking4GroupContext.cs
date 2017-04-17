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
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               
        }

        public DbSet<Looking4Group.Models.Forum> Forum { get; set; }
    }
}

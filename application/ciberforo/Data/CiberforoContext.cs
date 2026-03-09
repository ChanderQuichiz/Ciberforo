using Microsoft.EntityFrameworkCore;
using ciberforo.Entities;

namespace ciberforo.Data
{
    public class CiberforoContext(DbContextOptions<CiberforoContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Topic> Topics => Set<Topic>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<TopicReaction> TopicReactions => Set<TopicReaction>();
        public DbSet<Report> Reports => Set<Report>();

        
    }
}

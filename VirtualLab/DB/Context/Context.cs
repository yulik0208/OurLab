using System.Data.Entity;
using VirtualLab.DB.Models;

namespace VirtualLab.DB.Context
{
    class Context : DbContext
    {
        public Context() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Support> Supports{ get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Topic> Topics { get; set; }


    }
}

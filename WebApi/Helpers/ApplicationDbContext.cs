using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogStatus> BlogStatuses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<ReadList> ReadLists { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagBlog> TagBlogs { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<BlogStatus>(entity =>
            {
                entity.HasData(
                    new BlogStatus { Pk = 1, Name = "Pending" },
                    new BlogStatus { Pk = 2, Name = "Approved" },
                    new BlogStatus { Pk = 3, Name = "Declined" }
                    );
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.HasData(
                    new IdentityRole { Name = "Admin", NormalizedName="ADMIN" },
                    new IdentityRole { Name = "Writer", NormalizedName="WRITER" }
                    );
            });

            modelBuilder.Entity<ReadList>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<TagBlog>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
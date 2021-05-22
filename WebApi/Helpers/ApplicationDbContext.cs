using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Helpers
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedOn = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedOn = utcNow;
                            trackable.UpdatedOn = utcNow;
                            break;
                    }
                }
            }
        }

       public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogStatus> BlogStatuses { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<ReadList> ReadLists { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        //public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<BlogStatus>(entity =>
            {
                entity.HasData(
                    new BlogStatus { Pk = (int)BlogState.Draft, Name = "Draft" },
                    new BlogStatus { Pk = (int)BlogState.Pending, Name = "Pending" },
                    new BlogStatus { Pk = (int)BlogState.Approved, Name = "Approved" },
                    new BlogStatus { Pk = (int)BlogState.Declined, Name = "Declined" }
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

        }
    }
}
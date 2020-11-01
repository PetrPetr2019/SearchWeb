using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebSearch
{
    public partial class SearchWebContext : DbContext
    {
        public SearchWebContext()
        {
        }

        public SearchWebContext(DbContextOptions<SearchWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Live> Live { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SearchWeb;Trusted_Connection=True;");
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Live>(entity =>
            {
                entity.ToTable("live");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

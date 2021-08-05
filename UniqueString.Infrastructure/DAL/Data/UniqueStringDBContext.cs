using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueString.Core.Entities;

namespace UniqueString.Infrastructure.DAL.Data
{
    public class UniqueStringDBContext : DbContext
    {
        public UniqueStringDBContext(DbContextOptions<UniqueStringDBContext> options)
     : base(options)
        {

        }
        public DbSet<UniqueStringEntity> UniqueStrings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnUniqueStringModelCreate(modelBuilder);
        }

        private void OnUniqueStringModelCreate(ModelBuilder model)
        {
            model.Entity<UniqueStringEntity>(entity =>
            {
                entity.HasKey(e => e.Text);
                entity.Property(e => e.Text).HasMaxLength(512);
                entity.HasIndex(e => e.Text).IsUnique(true);
                entity.ToTable("UniqueString");
            });
        }
    }
}

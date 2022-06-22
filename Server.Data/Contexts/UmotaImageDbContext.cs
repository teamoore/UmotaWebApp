using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;

namespace UmotaWebApp.Server.Data.Contexts
{
    public partial class UmotaImageDbContext : DbContext
    {
        public UmotaImageDbContext()
        {
        }

        public UmotaImageDbContext(DbContextOptions<UmotaImageDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ImageData> ImageDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<ImageData>(entity => 
            {
                entity.HasKey(e => e.Logref).HasName("PK_imagedata");

                entity.ToTable("imagedata");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.FileName)
                    .HasColumnName("ifilename");

                entity.Property(e => e.iData)
                    .HasColumnName("idata")
                    .HasColumnType("image");

                entity.Property(e => e.iType)
                    .HasColumnName("itype");

                entity.Property(e => e.TableLogref)
                    .HasColumnName("tablelogref");

                entity.Property(e => e.TableName)
                    .HasColumnName("tablename");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

            });
        }
    }
}

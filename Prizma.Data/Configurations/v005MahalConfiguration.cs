using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ScaffoldModels;

namespace Prizma.Data.Configurations
{
    public class v005MahalConfiguration : IEntityTypeConfiguration<V005Mahal>
    {
        public void Configure(EntityTypeBuilder<V005Mahal> builder)
        {
            builder.HasNoKey().ToView("v005_mahal");

            builder.Property(e => e.Logref).HasColumnName("logref");
            builder.Property(e => e.Projeref).HasColumnName("projeref");
            builder.Property(e => e.Adi).HasColumnName("adi");
            builder.Property(e => e.Turref).HasColumnName("turref");
            builder.Property(e => e.Projeadi).HasColumnName("projeadi");
            builder.Property(e => e.Turadi).HasColumnName("turadi");
        }
    }
}

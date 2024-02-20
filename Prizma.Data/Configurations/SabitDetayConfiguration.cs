using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Data.Configurations
{
    public class SabitDetayConfiguration : IEntityTypeConfiguration<SabitDetay>
    {
        public void Configure(EntityTypeBuilder<SabitDetay> builder)
        {
            builder.ToTable("sis_sabitler_detay");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("sabit_detay_id");
            builder.Property(x => x.TipId).HasColumnName("tip");
            builder.Property(x => x.Kodu).HasColumnName("kodu");
            builder.Property(x => x.Adi).HasColumnName("adi");
        }
    }
}

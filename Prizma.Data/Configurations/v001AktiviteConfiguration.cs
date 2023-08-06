using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmotaWebApp.Shared;

namespace Prizma.Data.Configurations
{
    public class v001AktiviteConfiguration : IEntityTypeConfiguration<V001Aktivite>
    {
        public void Configure(EntityTypeBuilder<V001Aktivite> builder)
        {
            builder.HasNoKey().ToView("v001_aktivite");

            builder.Property(x => x.Logref).HasColumnName("logref");
            builder.Property(x => x.Parlogref).HasColumnName("parlogref");
            builder.Property(x => x.Kodu).HasColumnName("kodu");
            builder.Property(x => x.Adi).HasColumnName("adi");
            builder.Property(x => x.Uzunadi).HasColumnName("uzunadi");
            builder.Property(x => x.Uzunkodu).HasColumnName("uzunkodu");
        }
    }
}

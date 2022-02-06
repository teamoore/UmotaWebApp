using System;
using Microsoft.EntityFrameworkCore;
using UmotaWebApp.Server.Data.Models;

namespace UmotaWebApp.Server.Data.Contexts
{
    public class UmotaMasterDbContextHelper
    {
        public static void CreateRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SisFirmaDonem>()
                .HasOne<SisFirma>()
                .WithMany()
                .HasForeignKey(s => s.FirmaNo);

        }
    }
}

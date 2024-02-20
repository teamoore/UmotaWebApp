using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Data
{
    public class MasterDbContext : DbContext
    {
        public DbSet<SabitDetay> SabitDetay {  get; set; }

        public MasterDbContext(DbContextOptions<MasterDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SabitDetayConfiguration());
        }
    }
}

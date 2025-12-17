using Microsoft.EntityFrameworkCore;
using FitnessApp.Models;

namespace FitnessApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Salon> Salonlar { get; set; }
        public DbSet<Egitmen> Egitmenler { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }


        // --- İŞTE O HATAYI ÇÖZEN SİHİRLİ KOD BURADA ---
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Randevu silinirken Eğitmen silinmesin (Restrict)
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Egitmen)
                .WithMany()
                .HasForeignKey(r => r.EgitmenId)
                .OnDelete(DeleteBehavior.Restrict);

            // Randevu silinirken Hizmet silinmesin (Restrict)
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Hizmet)
                .WithMany()
                .HasForeignKey(r => r.HizmetId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        // ---------------------------------------------
    }
}
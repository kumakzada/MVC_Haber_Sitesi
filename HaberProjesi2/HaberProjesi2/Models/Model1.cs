namespace HaberProjesi2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<Haber> Haber { get; set; }
        public virtual DbSet<HaberTipi> HaberTipi { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Resim> Resim { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yazar1> Yazar1 { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HaberTipi>()
                .HasMany(e => e.Haber)
                .WithOptional(e => e.HaberTipi1)
                .HasForeignKey(e => e.HaberTipi);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Yazar1>()
                .HasMany(e => e.Haber)
                .WithOptional(e => e.Yazar1)
                .HasForeignKey(e => e.YazarID);
        }
    }
}

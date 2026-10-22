using BLM4581Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BLM4581Mvc.Data
{
    public class KitapDbContext : DbContext
    {
        public KitapDbContext(DbContextOptions<KitapDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; } = default!;
        public DbSet<Kategori> Kategoriler { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { Id = 1, Ad = "Roman" },
                new Kategori { Id = 2, Ad = "Öykü" },
                new Kategori { Id = 3, Ad = "Bilim" },
                new Kategori { Id = 4, Ad = "Tarih" }
            );
            modelBuilder.Entity<Kitap>().HasData(
                new Kitap
                {
                    Id = 1,
                    Ad = "Tutunamayanlar",
                    Yazar = "Oğuz Atay",
                    BasimYili = 1972,
                    SayfaSayisi = 724,
                    KategoriId = 1
                },
                new Kitap
                {
                    Id = 2,
                    Ad = "Kuyucaklı Yusuf",
                    Yazar = "Sabahattin Ali",
                    BasimYili = 1937,
                    SayfaSayisi = 216,
                    KategoriId = 1
                },
                new Kitap
                {
                    Id = 3,
                    Ad = "Semaver",
                    Yazar = "Sait Faik Abasıyanık",
                    BasimYili = 1936,
                    SayfaSayisi = 120,
                    KategoriId = 2
                },
                new Kitap
                {
                    Id = 4,
                    Ad = "Kozmos",
                    Yazar = "Carl Sagan",
                    BasimYili = 1980,
                    SayfaSayisi = 396,
                    KategoriId = 3
                }
            );
        }
    }
}

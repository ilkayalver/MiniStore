using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniStore.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.WebAPI.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public virtual void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.PhotoUrl).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

            builder.HasData(
                new Product { Id = 1, Name = "MiniStore Elbise Siyah", CategoryId = 4, Stock = 10, PhotoUrl = "images/KadinElbise.jpg", Price = 150 },
                new Product { Id = 2, Name = "Mini-Store Deri Bot", CategoryId = 5, Stock = 5, PhotoUrl = "images/ErkekAyakkabi.jpg", Price = 200 },
                new Product { Id = 3, Name = "Mini-Store Kadın Şampuan Elseve ", CategoryId = 6, Stock = 2, PhotoUrl = "images/SacBakimKadinSampuan.jpg", Price = 18 },
                new Product { Id = 4, Name = "Mini-Store Erkek Şampuan ClearMen-Mentol", CategoryId = 6, Stock = 2, PhotoUrl = "images/SacBakimErkekSampuan.jpg", Price = 17.5 },
                new Product { Id = 5, Name = "Mini-Store Kadın&Erkek Şampuan (avantajlı paket)", CategoryId = 6, Stock = 5, PhotoUrl = "images/KadinVeErkekSampuanIkiliPaket.jpg", Price = 35 }
            );
        }
    }
}

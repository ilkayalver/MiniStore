using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniStore.WebAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniStore.WebAPI.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public virtual void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.HasOne(x => x.ParentCategory).WithOne().HasForeignKey<Category>(x => x.ParentCategoryId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Category { Id = 1, Name = "KADIN", ParentCategoryId = null },
                new Category { Id = 2, Name = "ERKEK", ParentCategoryId = null },
                new Category { Id = 3, Name = "KOZMETİK", ParentCategoryId = null },
                new Category { Id = 4, Name = "Giyim", ParentCategoryId = 1 },
                new Category { Id = 5, Name = "Ayakkabı", ParentCategoryId = 2 },
                new Category { Id = 6, Name = "Saç Bakımı", ParentCategoryId = 3 }
            );
        }
    }
}

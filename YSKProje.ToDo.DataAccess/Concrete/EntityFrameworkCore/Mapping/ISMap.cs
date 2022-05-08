using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ISMap : IEntityTypeConfiguration<Is>
    {
        public void Configure(EntityTypeBuilder<Is> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Ad).HasMaxLength(200);
            builder.Property(I => I.Aciklama).HasColumnType("ntext");

            builder.HasOne(t => t.Vaciblik)
           .WithMany(Vaciblik => Vaciblik.Isler)
           .HasForeignKey(z => z.VaciblikId);
        }
    }
}

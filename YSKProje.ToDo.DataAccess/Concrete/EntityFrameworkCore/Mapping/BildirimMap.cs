using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BildirimMap : IEntityTypeConfiguration<Bildiris>
    {
        public void Configure(EntityTypeBuilder<Bildiris> builder)
        {
           builder.HasKey(B=>B.Id);
            builder.Property(B => B.Id).UseIdentityColumn();

            builder.Property(B => B.Aciklama).HasColumnType("ntext").IsRequired();

            builder.HasOne(B => B.AppUser).WithMany(Ap => Ap.Bildirises).HasForeignKey(B => B.AppUserId);

        }
    }
}

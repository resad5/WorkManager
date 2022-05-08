using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class RaporMAp : IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> builder)
        {
            builder.HasKey(R => R.Id);
            builder.Property(R => R.Id).UseIdentityColumn();
            builder.Property(R => R.Tanim).HasMaxLength(100).IsRequired();
            builder.Property(R => R.Detay).HasColumnType("ntext");

            builder.HasOne(R => R.Is).WithMany(T=> T.Rapors).HasForeignKey(R => R.IsId);


        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class VaciblikMaps : IEntityTypeConfiguration<Vaciblik>
    {
        public void Configure(EntityTypeBuilder<Vaciblik> builder)
        {
            builder.Property(I => I.Ifade).HasMaxLength(100);
        }
    }
}

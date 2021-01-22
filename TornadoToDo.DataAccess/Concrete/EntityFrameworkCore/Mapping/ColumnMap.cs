using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ColumnMap : IEntityTypeConfiguration<Column>
    {
        public void Configure(EntityTypeBuilder<Column> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(100);

            builder.HasMany(I => I.Cards).WithOne(I => I.Column).HasForeignKey(I => I.ColumnId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

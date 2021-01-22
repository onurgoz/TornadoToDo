using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BoardMap : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(100).IsRequired();

            builder.HasMany(I => I.Columns).WithOne(I => I.Board).HasForeignKey(I => I.BoardId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CardMap : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(50);
            builder.Property(I => I.Note).HasMaxLength(500);

        }
    }
}

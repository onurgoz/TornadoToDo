using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(30).IsRequired();

            builder.Property(I => I.Username).HasMaxLength(50).IsRequired();

            builder.HasMany(I => I.Boards).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

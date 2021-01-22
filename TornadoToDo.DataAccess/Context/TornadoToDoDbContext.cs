using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using TornadoToDo.Entities.Concrete;

namespace TornadoToDo.DataAccess.Context
{
    public class TornadoToDoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-39PR7AQ; Database=TornadoDb;uid=sa;pwd=1234;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new BoardMap());
            modelBuilder.ApplyConfiguration(new CardMap());
            modelBuilder.ApplyConfiguration(new ColumnMap());
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Column> Columns { get; set; }
    }
}

using Library.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class AppDB : DbContext
    {


        public DbSet<User_Cards> Cards { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("   Data Source = WIN-EA8010O87DM;Initial Catalog=Library;Integrated Security = True; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Car>()
            //    .HasAlternateKey(e => e.Number);
            modelBuilder.Entity<User>()
                .HasMany(r => r.Card)
                .WithOne(d => d.user)
                .HasForeignKey(r => r.user_id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
              .HasMany(s => s.Cards)
              .WithOne(r => r.book)
              .HasForeignKey(s => s.book_id)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

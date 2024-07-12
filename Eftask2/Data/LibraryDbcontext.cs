using Eftask2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
namespace Eftask2.Data
{
    public class LibraryDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Librarian> Librarians  { get; set; }
        public DbSet<S_Cards> S_Cards  { get; set; }
        public DbSet<Student> Students { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(e => e.IdAuthor)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
            .HasMany(e => e.Books)
            .WithOne(a => a.Category)
            .HasForeignKey(a => a.IdCategory)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<S_Cards>()
                .HasOne(e => e.Book)
                .WithMany(a => a.S_Cards)
                .HasForeignKey(a => a.Id_Book)
                .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Librarian>()
                     .HasMany(e => e.S_Cards)
                     .WithOne(e => e.Lib)
                     .HasForeignKey(e => e.Id_Lib)
                     .IsRequired()
                     .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>()
             .HasMany(a => a.S_Cards)
             .WithOne(a => a.Student)
             .HasForeignKey(a => a.Id_Student)
            .IsRequired()
                     .OnDelete(DeleteBehavior.NoAction);


        }



    }
}

using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkTest.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Student>()
                .HasData(
                    new Student { StudentId = 1, FirstName = "Florian", LastName = "Esprit"},
                    new Student { StudentId = 2, FirstName = "Sagar", LastName = "Bhanadari" },
                    new Student { StudentId = 3, FirstName = "Olga", LastName = "Kharchuk"},
                    new Student { StudentId = 4, FirstName = "Akin", LastName = "Baroti" }
                );

            modelBuilder.Entity<Book>()
                .HasData
                (
                new Book { BookId = 1, Title = "Vahana Masterclass", Published = new DateTime(1988, 02, 21),StudentId=1 },
                new Book { BookId = 2, Title = "Right Under Our Nose", Published = new DateTime(2000, 11, 21), StudentId=1},
                new Book { BookId = 3, Title = "The Commonwealth of Cricket", Published = new DateTime(1986, 01, 15), StudentId=2},
                new Book { BookId = 4, Title = "The Little Book of Encouragement", Published = new DateTime(2005, 12, 15) , StudentId=3}
                );

            modelBuilder.Entity<Author>()
              .HasData
              (
              new Author { AuthorId = 1, Name = "Alfredo ", SurName = "Covelli" },
              new Author { AuthorId = 2, Name = "Ramachandra ", SurName = "Guha" },
              new Author { AuthorId = 3, Name = "Waman Subha ", SurName = "Prabhu" },
              new Author { AuthorId = 4, Name = "Dalai ", SurName = "Lama" }
              );
            modelBuilder.Entity<AuthorBook>()
                .HasData
                (
                new AuthorBook { AuthorBookId = 1, AuthorId = 1, BookId = 1 },
                new AuthorBook { AuthorBookId = 2, AuthorId = 2, BookId = 2 },
                new AuthorBook { AuthorBookId = 3, AuthorId = 3, BookId = 3 },
                new AuthorBook { AuthorBookId = 4, AuthorId = 4, BookId = 4 },
                new AuthorBook { AuthorBookId = 5, AuthorId = 2, BookId = 3 }
                );

            //configure many to many keys
            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.BookId, ab.AuthorId });

            //setup one-to-many rel authorsbook => books
            modelBuilder.Entity<AuthorBook>()
                .HasOne<Book>(ab => ab.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(b => b.BookId);

            // setup one-to-many rel authorsbook => author
            modelBuilder.Entity<AuthorBook>()
              .HasOne<Author>(ab => ab.Author)
              .WithMany(b => b.AuthorBooks)
              .HasForeignKey(b => b.AuthorId);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
       
        public DbSet<AuthorBook> AuthorBooks { get; set; }

    }
}

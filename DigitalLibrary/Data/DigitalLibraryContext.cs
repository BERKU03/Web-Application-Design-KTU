using DigitalLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Data
{
    public class DigitalLibraryContext : DbContext
    {
        // Constructor para las dependencias
        public DigitalLibraryContext(DbContextOptions<DigitalLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fantasy",Description = "Stories involving magic, mythical creatures, and adventures." },
                new Category { Id = 2, Name = "Dystopia",Description = "Fictional societies characterized by oppression and control." }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    Description = "A fantasy adventure about Bilbo Baggins and his journey to reclaim a lost treasure.",
                    PublicationDate = new DateTime(1937, 9, 21),
                    File = "/files/the-hobbit.pdf",
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "A dystopian novel about totalitarianism and surveillance.",
                    PublicationDate = new DateTime(1949, 6, 8),
                    File = "/files/1984.pdf",
                    CategoryId = 2
                });

                modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin User",
                    Email = "admin@library.com",
                    Password = "admin123",
                    Role = "administrator"
                },
                new User
                {
                    Id = 2,
                    Name = "berku gonzalez",
                    Email = "berku@library.com",
                    Password = "berku",
                    Role = "member"
                },
                new User
                {
                    Id = 3,
                    Name = "Alice garcia",
                    Email = "Alice@library.com",
                    Password = "Alice",
                    Role = "member"
                }
            );
        }
    }
}
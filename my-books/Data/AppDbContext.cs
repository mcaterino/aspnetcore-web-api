using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Book)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(bi => bi.BooksId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne(b => b.Author)
                .WithMany(ab => ab.AuthorBooks)
                .HasForeignKey(ai => ai.AuthorsId);

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
       
    }
}

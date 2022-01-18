using Microsoft.EntityFrameworkCore.ChangeTracking;
using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        
        public void Add(BookVM book)
        {
            var _book = new Book() 
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        
        public Book GetBookById(int id)
        {
            var result = _context.Books.FirstOrDefault(b => b.Id == id);
            return result;
        }

        public Book UpdateBookById(int id, BookVM book)
        {
            var result = _context.Books.FirstOrDefault(b => b.Id == id);
            
            if (result != null)
            {
                result.Title = book.Title;
                result.Description = book.Description;
                result.IsRead = book.IsRead;
                result.DateRead = book.IsRead ? book.DateRead.Value : null;
                result.Rate = book.IsRead ? book.Rate.Value : null;
                result.Genre = book.Genre;
                result.Author = book.Author;
                result.CoverUrl = book.CoverUrl;
                
                _context.SaveChanges();
            }
          
            return result;
        }

        public void DeleteBookById(int id)
        {
            var result = _context.Books.FirstOrDefault(b => b.Id == id);
            if (result != null)
            {
                _context.Books.Remove(result);
                _context.SaveChanges(); 
            }
        }

    }
}

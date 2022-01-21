using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int id)
        {
            var _authorWithBooks = _context.Authors.Where(a => a.Id == id).Select(a => new AuthorWithBooksVM()
            {
                FullName = a.FullName,
                BookTitles = a.AuthorBooks.Select(a => a.Book.Title).ToList()
            }).FirstOrDefault();

            return _authorWithBooks;
        }
        public List<Author> GetAllAuthors() 
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            var result = _context.Authors.FirstOrDefault(a => a.Id == id);
            return result;
        }

        public Author UpdateAuthorById(int id, AuthorVM author)
        {
            var result = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                result.FullName = author.FullName;
                _context.SaveChanges();
            }
            return result;
        }

        public void DeleteAuthorById(int id)
        {
            var result = _context.Authors.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _context.Authors.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}

﻿using my_books.Data.Models;
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
            _context.Author.Add(_author);
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthors() 
        {
            return _context.Author.ToList();
        }

        public Author GetAuthorById(int id)
        {
            var result = _context.Author.FirstOrDefault(a => a.Id == id);
            return result;
        }

        public Author UpdateAuthorById(int id, AuthorVM author)
        {
            var result = _context.Author.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                result.FullName = author.FullName;
                _context.SaveChanges();
            }
            return result;
        }

        public void DeleteAuthorById(int id)
        {
            var result = _context.Author.FirstOrDefault(a => a.Id == id);
            if (result != null)
            {
                _context.Author.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}

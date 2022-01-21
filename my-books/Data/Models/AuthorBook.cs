using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class AuthorBook
    {
        [Key]
        public int Id { get; set; }
        public int AuthorsId { get; set; }
        public Author Author { get; set; }
        public int BooksId { get; set; }
        public Book Book { get; set; }
    }
}

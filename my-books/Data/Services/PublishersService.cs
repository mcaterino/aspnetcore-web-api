using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private readonly AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.FullName
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetAllPublisher()
        {
            return _context.Publishers.ToList();
        }

        public Publisher GetPublisherById(int id)
        {
            var result = _context.Publishers.FirstOrDefault(p => p.Id == id);
            return result;
        }

        public Publisher UpdatePublisherById(int id, PublisherVM publisher)
        {
            var result = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                result.Name = publisher.FullName;
                _context.SaveChanges();
            }
            return result;
        }

        public void DeletePublisherById(int id)
        {
            var result = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.Publishers.Remove(result);
                _context.SaveChanges(); 
            }
        }
    }
}

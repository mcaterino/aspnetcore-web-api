using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(
                        new Publisher
                        {
                            Name = "Addison-Wesley"
                        },
                        new Publisher
                        {
                            Name = "Microsoft Press"
                        },
                        new Publisher
                        {
                            Name = "O'Reilly"
                        },
                        new Publisher
                        {
                            Name = "William Pollock"
                        }
                    );
                    context.SaveChanges();
                }
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(
                        new Author
                        {
                            FullName = "Jhon Sharp"
                        },
                        new Author
                        {
                            FullName = "Marinj Heverbeke"
                        },
                        new Author
                        {
                            FullName = "Len Bass"
                        },
                        new Author
                        {
                            FullName = "Paul Clements"
                        },
                        new Author
                        {
                           FullName = "Rick Kazman"
                        },
                        new Author
                        {
                            FullName = "Eva Tuczai"
                        },
                        new Author
                        {
                            FullName = "Asena Hertz"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}

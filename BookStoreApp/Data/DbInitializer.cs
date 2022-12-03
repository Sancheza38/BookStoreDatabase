using BookStoreApp.Models;
using System.Diagnostics;

namespace BookStoreApp.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            // Look for any Books.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var admin = new Customer[]
            {
                new Customer{Username = "admin@email.com", Fname="josh", Lname="barnes"}
            };
            context.Customers.AddRange(admin);
            context.SaveChanges();

            var bookCategories = new BookCategory[]
            {
                new BookCategory{CategoryCode=1,CategoryDescription="Fiction"},
                new BookCategory{CategoryCode=2,CategoryDescription="Action/Adventure"},
                new BookCategory{CategoryCode=3,CategoryDescription="History"},
                new BookCategory{CategoryCode=4,CategoryDescription="Anthology"},
                new BookCategory{CategoryCode=5,CategoryDescription="Childern's"},
                new BookCategory{CategoryCode=6,CategoryDescription="Classic"},
                new BookCategory{CategoryCode=7,CategoryDescription="Comic Book"},
                new BookCategory{CategoryCode=8,CategoryDescription="Crime"},
                new BookCategory{CategoryCode=9,CategoryDescription="Drama"},
                new BookCategory{CategoryCode=10,CategoryDescription="Fairytale"},
                new BookCategory{CategoryCode=11,CategoryDescription="Biography"},
                new BookCategory{CategoryCode=12,CategoryDescription="Buisness/economics"}
            };

            context.Categories.AddRange(bookCategories);
            context.SaveChanges();

            var books = new Book[]
            {
                new Book{ISBN=1111111111, Title="Book 1", PublicationDate=DateTime.Parse("01/01/2000"), Price=decimal.Parse("10.99"), UserReview=1},
                new Book{ISBN=2222222222, Title="Book 2", PublicationDate=DateTime.Parse("02/02/2003"), Price=decimal.Parse("12.99"), UserReview=3},
                new Book{ISBN=3333333333, Title="Book 3", PublicationDate=DateTime.Parse("03/15/2004"), Price=decimal.Parse("15.99"), UserReview=4},
                new Book{ISBN=4444444444, Title="Book 4", PublicationDate=DateTime.Parse("01/24/2005"), Price=decimal.Parse("2.99"), UserReview=1},
                new Book{ISBN = 5555555555, Title = "Book 5", PublicationDate = DateTime.Parse("03/21/2006"), Price = decimal.Parse("18.99"), UserReview = 5},
                new Book{ISBN = 7777777777, Title = "Book 7", PublicationDate = DateTime.Parse("08/06/2007"), Price = decimal.Parse("13.99"), UserReview = 3},
                new Book{ISBN = 8888888888, Title = "Book 8", PublicationDate = DateTime.Parse("04/08/2008"), Price = decimal.Parse("17.99"), UserReview = 2},
                new Book{ISBN = 9999999999, Title = "Book 9", PublicationDate = DateTime.Parse("06/04/2009"), Price = decimal.Parse("20.99"), UserReview = 5}
            };

            context.Books.AddRange(books);
            context.SaveChanges();

            var authors = new AuthorOfBooks[]
            {
                new AuthorOfBooks{Fname="James", Lname="Smith", Gender="Male", DateOfBirth=DateTime.Parse("02/23/1988")},
                new AuthorOfBooks{Fname="samantha", Lname="Adams", Gender="Female", DateOfBirth=DateTime.Parse("02/23/1988")},
                new AuthorOfBooks{Fname="Oscar", Lname="Turner", Gender="Male", DateOfBirth=DateTime.Parse("02/23/1988")},
                new AuthorOfBooks{Fname="John", Lname="Marker", Gender="Male", DateOfBirth=DateTime.Parse("02/23/1988")},
                new AuthorOfBooks{Fname="Donella", Lname="Armster", Gender="Female", DateOfBirth=DateTime.Parse("02/23/1988")},
                new AuthorOfBooks{Fname="Gary", Lname="Starr", Gender="Male", DateOfBirth=DateTime.Parse("02/23/1988")},
                new AuthorOfBooks{Fname="Charles", Lname="Dahmer", Gender="Male", DateOfBirth=DateTime.Parse("02/23/1988")}
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var writes = new Write[]
            {
                new Write{AuthorID=1,ISBN=1111111111},
                new Write{AuthorID=2,ISBN=2222222222},
                new Write{AuthorID=3,ISBN=3333333333},
                new Write{AuthorID=4,ISBN=4444444444},
                new Write{AuthorID=5,ISBN=5555555555},
                new Write{AuthorID=6,ISBN=7777777777},
                new Write{AuthorID=7,ISBN=8888888888},
                new Write{AuthorID=3,ISBN=9999999999},
                new Write{AuthorID=6,ISBN=2222222222},
                new Write{AuthorID=2,ISBN=3333333333},
                new Write{AuthorID=4,ISBN=7777777777},
                new Write{AuthorID=1,ISBN=4444444444}
            };

            context.Writes.AddRange(writes);
            context.SaveChanges();
        }
    }
}

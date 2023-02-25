

using Liblary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Runtime.CompilerServices;
using AppContext = Liblary.AppContext;

public class Program
{
    private static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            db.Database.EnsureDeleted();

            var store = new User { Name = "Lib", Email = "LIB" };
            var user1 = new User { Name = "Alice", Email = "erge@gmail.com" };
            var user2 = new User { Name = "Bob", Email = "ertjstye@gmail.com" };
            var user3 = new User { Name = "Bruce", Email = "5563fy@gmail.com" };
            var user4 = new User { Name = "Kate", Email = "wefwq@@gmail.com" };

            db.Users.AddRange(store, user1, user2, user3, user4);

            var book1 = new Book { Name = "The mouse trap", Year = 1952, Author = "Agatha Christie", Genre = "Piece", user = user1};
            var book2 = new Book { Name = "The Adventures of Tom Sawyer", Year = 1976, Author = "Mark Twen", Genre = "Adventure", user = store}; 
            var book3 = new Book { Name = "Alice in Wonderland", Year = 1865, Author = "Luise Kerrol", Genre = "Fairy tale", user = user3 };
            var book4 = new Book { Name = "War and Peace", Year = 1869, Author = "Lev Tolstoy", Genre = "Roman", user = store};

            db.Books.AddRange(book1, book2, book3, book4);

            db.Database.EnsureCreated();


            //db.Users.Where(user => user.Role == "Admin").ExecuteDelete();
            db.SaveChanges();
  
        }

        //GenreYear("Piece", 1900, 2000);
        // AuthorBookCount("Lev Tolstoy");
        //Console.WriteLine(BoolBookOnHand("War and Peace"));
        //UserBookOnHandCount("Bob");
        //LastYearBook();
        //PrintAllBookSorted();
        PrintAllBookYearSorted();
    }
    public static void GenreYear(string genre, int datain, int dataout)
    {
        using(var db = new AppContext())
        {
            var query = db.Books.Where(e => e.Genre == genre).Where(e => e.Year > datain && e.Year < dataout).ToList();

            foreach (var item in query) Console.WriteLine(item.Id + "| " + item.Name + "| " + item.Genre + "| " + item.Author);
        }
    }
    public static void AuthorBookCount(string author)
    {
        using(var db = new AppContext())
        {
            var query = db.Books.Where(e => e.Author == author).Count();
            Console.WriteLine(query);
        }
    }
    public static void GenreBookCount(string genre)
    {
        using (var db = new AppContext())
        {
            var query = db.Books.Where(e => e.Genre == genre).Count();
            Console.WriteLine(query);
        }
    }
    public static bool BoolAuthorGenreInLibrary(string author, string name)
    {
        using (var db = new AppContext())
        {
            var query = db.Books.Where(e => e.Author == author).Where(u => u.Name == name).Count();
            if(query > 0) return true;
            else return false;
        }
    }
    public static bool BoolBookOnHand(string name)
    {
        using (var db = new AppContext())
        {
            var query = db.Books.Where(u => u.Name == name).Where(e => e.user.Id > 1).Count();
            if (query > 0) return true;
            else return false;
        }
    }
    public static void UserBookOnHandCount(string name)
    {
        using (var db = new AppContext())
        {
            var queryUser = db.Users.Where(u => u.Name == name).ToList();
            int value = 0;
            foreach (var user in queryUser) value = user.Id;
            var query = db.Books.Where(e => e.user.Id == value).Count();
            Console.WriteLine(query);
        }
    }
    public static void LastYearBook()
    {
        using(var db = new AppContext())
        {
            var query = db.Books.OrderBy(u => u.Year).ToList();
            Console.WriteLine(query.Last().Name);
        }
    }
    public static void PrintAllBookSorted()
    {
        using(var db = new AppContext())
        {
            var query = db.Books.OrderBy(u => u.Name).ToList();
            foreach (var book in query) Console.WriteLine(book.Name);
        }
    }
    public static void PrintAllBookYearSorted()
    {
        using (var db = new AppContext())
        {
            var query = db.Books.OrderByDescending(u => u.Year).ToList();
            foreach (var book in query) Console.WriteLine(book.Name);
        }
    }

}
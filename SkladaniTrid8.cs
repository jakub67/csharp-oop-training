using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skladani8 {
    class Book {
        string title;
        Author author;
        int pages;
        double price;
        bool avaible;
        public string Title { get => title; set => title = value; }
        public int Pages { get => pages; set => pages = value; }
        public double Price { get => price; set => price = value; }
        public bool Avaible { get => avaible; set => avaible = value; }
        internal Author Author { get => author; set => author = value; }
        public Book(string title, Author author, int pages, double price, bool avaible) {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.price = price;
            this.avaible = avaible;
            author.Books.Add(this);
        }
        public override string ToString() {
            return $"Nazev knihy: {title} Autor: {author} Strany: {pages} Cena: {price} Dostupnost: {avaible}";
        }
    }
    class Author {
        string firstName;
        string lastName;
        List<Book> books = new List<Book>();
        DateTime dateOfBirth;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        internal List<Book> Books { get => books; set => books = value; }
        public Author(string firstName, string lastName, DateTime dateOfBirth) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }
        public void listBooks() {
            foreach (var i in Books) {
                Console.WriteLine($"Jmeno: {i.Author.FirstName} Prijmeni: {i.Author.LastName} Nazev: {i.Title} Cena: {i.Price} Narozen:{i.Author.DateOfBirth.Year}");
            }
        }
        public override string ToString() {
            return $"Jmeno: {firstName} Prijmeni: {lastName} Narozen: {dateOfBirth.Year}";
        }
    }
    class Reader {
        string firstName;
        string lastName;
        List<Book> myBooks = new List<Book>();
        DateTime dateOfBirth;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        internal List<Book> MyBooks { get => myBooks; set => myBooks = value; }

        public Reader(string firstName, string lastName, DateTime dateOfBirth) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }
        public void borrowBook(Book b) {
            if (b.Avaible) { myBooks.Add(b); }
            b.Avaible = false;
        }
        public void returnBook(Book b) {
            myBooks.Remove(b);
            b.Avaible = true;
        }
        public void listBorrowed() {
            foreach (var i in myBooks) {
                Console.WriteLine($"Jmeno: {i.Author.FirstName} Prijmeni: {i.Author.LastName} Nazev: {i.Title} Narozen: {i.Author.DateOfBirth.Year}");
            }
        }        
    }
    class Library {
        List<Book> booksLib = new List<Book>();

        internal List<Book> BooksLib { get => booksLib; set => booksLib = value; }
        public void addBook(Book b) {
            //if(b == null){ b.Avaible = false; }
            if (b.GetType().Name.Contains("AnonymousType")) { b.Avaible = false; }
            booksLib.Add(b);
        }
        public void listAvailable() {
            foreach (var i in booksLib) {
                if (i.Avaible) { Console.WriteLine($"Jmeno: {i.Author.FirstName} Prijmeni: {i.Author.LastName} Nazev: {i.Title} Narozen: {i.Author.DateOfBirth.Year}"); }
            }
        }
        public void listUnavailable() {
            foreach (var i in booksLib) {
                if (!i.Avaible) { Console.WriteLine($"Jmeno: {i.Author.FirstName} Prijmeni: {i.Author.LastName} Nazev: {i.Title} Narozen: {i.Author.DateOfBirth.Year}"); }
            }
        }
        public void listAll() {
            foreach (var i in booksLib) {
                Console.WriteLine(i.Title+" "+i.Author+" "+i.Avaible);
            }
        }
    }
    class SkladaniTrid8 {
        public static void Mainx() {
            Author a1 = new Author("Karel", "Erben", new DateTime(1930, 9, 28));
            Author a2 = new Author("Jaroslav", "Vrchlicky", new DateTime(1950, 2, 17));
            Author a3 = new Author("Milan", "Kundera", new DateTime(1958, 1, 15));
            Book b1 = new Book("Zert", a3, 240, 400, true);
            Book b2 = new Book("Kytice", a1, 400, 800, true);
            Book b3 = new Book("Nesmrtelnost", a3, 240, 400, true);
            Reader r1 = new Reader("Jan", "Novy", new DateTime(1990, 2, 7));
            Library l1 = new Library();
            l1.addBook(b1);
            l1.addBook(b2);
            l1.addBook(b3);
            l1.addBook(new Book("Stavitele chramu",a2,300,450,true));
            r1.borrowBook(b1);
            r1.borrowBook(b2);
            r1.returnBook(b1);
            l1.listAll();
            Console.WriteLine();
            r1.listBorrowed();
            Console.WriteLine();
            l1.listAvailable();
            Console.WriteLine();
            a1.listBooks();
        }
    }
}

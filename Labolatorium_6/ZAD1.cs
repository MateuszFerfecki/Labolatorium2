using System;
using System.Collections.Generic;
using System.Linq;

// Definicje klas i interfejsów

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
}

public interface IPersonRepository
{
    List<Book> GetBorrowedBooksByPerson(int personId);
    void AddBorrowedBook(int personId, Book book);
}

public interface IBookRepository
{
    List<Book> GetBooksByAuthor(string author);
    List<Book> GetBooksByYear(int year);
}

// Implementacje klas

public class PersonRepository : IPersonRepository
{
    private List<Person> persons = new List<Person>();

    public List<Book> GetBorrowedBooksByPerson(int personId)
    {
        var person = persons.FirstOrDefault(p => p.Id == personId);
        if (person == null)
        {
            throw new Exception("Person not found.");
        }
        return person.BorrowedBooks;
    }

    public void AddBorrowedBook(int personId, Book book)
    {
        var person = persons.FirstOrDefault(p => p.Id == personId);
        if (person == null)
        {
            throw new Exception("Osoba nieznaleziona.");
        }
        person.BorrowedBooks.Add(book);
    }

    public void AddPerson(Person person)
    {
        persons.Add(person);
    }
}

public class BookRepository : IBookRepository
{
    private List<Book> books = new List<Book>();

    public List<Book> GetBooksByAuthor(string author)
    {
        return books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> GetBooksByYear(int year)
    {
        return books.Where(b => b.PublicationYear == year).ToList();
    }

    // Metoda do dodawania książek (pomocnicza)
    public void AddBook(Book book)
    {
        books.Add(book);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var personRepository = new PersonRepository();
        var bookRepository = new BookRepository();

        // Dodanie książek
        var book1 = new Book { Id = 1, Title = "C# for idiots", Author = "Mateusz Załocha", PublicationYear = 1720 };
        var book2 = new Book { Id = 2, Title = "Manifest o Lasach państwowych", Author = "Aleksandra Filipek", PublicationYear = 2021 };
        var book3 = new Book { Id = 3, Title = "pyton dla opornych", Author = "Tytus Bomba", PublicationYear = 2020 };

        bookRepository.AddBook(book1);
        bookRepository.AddBook(book2);
        bookRepository.AddBook(book3);

        // Dodanie osób
        var person1 = new Person { Id = 1, Name = "Alicja" };
        var person2 = new Person { Id = 2, Name = "Bob" };

        personRepository.AddPerson(person1);
        personRepository.AddPerson(person2);

        // Wypożyczenie książek
        personRepository.AddBorrowedBook(1, book1);
        personRepository.AddBorrowedBook(1, book3);

        // Wyświetlenie książek wypożyczonych przez osobę
        var borrowedBooks = personRepository.GetBorrowedBooksByPerson(1);
        Console.WriteLine("Książki przeglądane przez Alicje:");
        foreach (var book in borrowedBooks)
        {
            Console.WriteLine($"- {book.Title} by {book.Author}");
        }

        // Wyświetlenie książek autora
        var AleksandraFilipekBooks = bookRepository.GetBooksByAuthor("Aleksandra Filipek");
        Console.WriteLine("\nBooks od Aleksandra Filipek:");
        foreach (var book in AleksandraFilipekBooks)
        {
            Console.WriteLine($"- {book.Title} ({book.PublicationYear})");
        }

        // Wyświetlenie książek z danego roku
        var books1720 = bookRepository.GetBooksByYear(1720);
        Console.WriteLine("\nksiążki opublikowane w 1720:");
        foreach (var book in books1720)
        {
            Console.WriteLine($"- {book.Title} by {book.Author}");
        }
    }
}

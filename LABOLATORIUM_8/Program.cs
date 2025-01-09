using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty; // Default value
    public string Author { get; set; } = string.Empty; // Default value
    public int Year { get; set; }
}

public class FileBookManager
{
    private readonly string _filePath;

    public FileBookManager(string filePath)
    {
        _filePath = filePath;
        EnsureFileExists();
    }

    public void AddBook(Book book)
    {
        var books = GetAllBooks();
        books.Add(book);
        SaveBooksToFile(books);
    }

    public List<Book> GetAllBooks()
    {
        if (!File.Exists(_filePath))
            return new List<Book>();

        var json = File.ReadAllText(_filePath);
        return string.IsNullOrWhiteSpace(json)
            ? new List<Book>()
            : JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
    }

    public Book GetBookById(int id)
    {
        var books = GetAllBooks();
        return books.Find(book => book.Id == id);
    }

    public void RemoveBook(int id)
    {
        var books = GetAllBooks();
        var bookToRemove = books.Find(book => book.Id == id);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            SaveBooksToFile(books);
        }
    }

    public void UpdateBook(Book updatedBook)
    {
        var books = GetAllBooks();
        var index = books.FindIndex(book => book.Id == updatedBook.Id);
        if (index != -1)
        {
            books[index] = updatedBook;
            SaveBooksToFile(books);
        }
    }

    private void SaveBooksToFile(List<Book> books)
    {
        var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    private void EnsureFileExists()
    {
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]"); // Initialize an empty JSON array
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "books.json";
        var manager = new FileBookManager(filePath);

        var newBook = new Book
        {
            Id = 1,
            Title = "jak umieć programować",
            Author = "Mateusz Załocha",
            Year = 2137
        };

        manager.AddBook(newBook);

        var books = manager.GetAllBooks();
        foreach (var book in books)
        {
            Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
        }
    }
}

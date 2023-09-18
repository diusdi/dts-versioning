using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }

    public Book(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
    }
}

class LibraryCatalog
{
    private List<Book> books = new List<Book>();

    // Menambahkan buku ke dalam katalog
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Buku berhasil ditambahkan ke katalog.");
    }

    // Menghapus buku dari katalog
    public void RemoveBook(Book book)
    {
        if (books.Contains(book))
        {
            books.Remove(book);
            Console.WriteLine("Buku berhasil dihapus dari katalog.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan dalam katalog.");
        }
    }

    // Mencari buku berdasarkan judul
    public Book FindBook(string title)
    {
        foreach (var book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return book;
            }
        }

        // ketika tidak ditemukan akan mengembalikan nilai null
        return null;
    }

    // Menampilkan daftar semua buku dalam katalog
    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Katalog perpustakaan kosong.");
        }
        else
        {
            Console.WriteLine("Daftar buku dalam katalog:");
            foreach (var book in books)
            {
                Console.WriteLine($"Judul: {book.Title}, Pengarang: {book.Author}, Tahun Terbit: {book.PublicationYear}");
            }
        }
    }
}

// Class untuk menangani error
class ErrorHandler
{
    public static void HandleError(Exception e)
    {
        // menampilkan informasi error
        Console.WriteLine($"Terjadi kesalahan: {e.Message}");
    }
}

class LibraryApp
{
    static void Main(string[] args)
    {
        LibraryCatalog catalog = new LibraryCatalog();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nMenu Perpustakaan");
            Console.WriteLine("1. Tambah Buku");
            Console.WriteLine("2. Hapus Buku");
            Console.WriteLine("3. Cari Buku");
            Console.WriteLine("4. Tampilkan Semua Buku");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu (1-5): ");

            try
            {
                // menerima input dari pengguna
                int inputPilihan = int.Parse(Console.ReadLine());

                switch (inputPilihan)
                {
                    case 1:
                        Console.Write("Judul buku: ");
                        string title = Console.ReadLine();
                        Console.Write("Pengarang buku: ");
                        string author = Console.ReadLine();
                        Console.Write("Tahun terbit: ");
                        int publicationYear = int.Parse(Console.ReadLine());
                        Book newBook = new Book(title, author, publicationYear);
                        catalog.AddBook(newBook);
                        break;

                    case 2:
                        Console.Write("Judul buku yang akan dihapus: ");
                        string bookTitleToRemove = Console.ReadLine();
                        Book bookToRemove = catalog.FindBook(bookTitleToRemove);
                        if (bookToRemove != null)
                        {
                            catalog.RemoveBook(bookToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Buku tidak ditemukan dalam katalog.");
                        }
                        break;

                    case 3:
                        Console.Write("Judul buku yang dicari: ");
                        string bookTitleToFind = Console.ReadLine();
                        Book foundBook = catalog.FindBook(bookTitleToFind);
                        if (foundBook != null)
                        {
                            Console.WriteLine($"Buku ditemukan: Judul: {foundBook.Title}, Pengarang: {foundBook.Author}, Tahun Terbit: {foundBook.PublicationYear}");
                        }
                        else
                        {
                            Console.WriteLine("Buku tidak ditemukan dalam katalog.");
                        }
                        break;

                    case 4:
                        catalog.ListBooks();
                        break;

                    case 5:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak valid. Masukkan angka dari 1 hingga 5.");
                        break;
                }
            }
            catch (FormatException)
            // menampilkan informasi error ketika input selain angka
            {
                ErrorHandler.HandleError(new Exception("Format input tidak valid. Masukkan angka."));
            }
            catch (Exception e)
            {
                ErrorHandler.HandleError(e);
            }
        }
    }
}

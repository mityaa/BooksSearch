using System;
using System.Linq;
using DataAccessLayer;

namespace BookDirectoryScheduler
{
    class Program
    {
        private const string BookDir = @"C:\\Books";
        private static readonly IBookService BookService = new BookService();

        static void Main(string[] args)
        {
            Console.WriteLine("Scheduler is running");
            //Starts every 10 seconds

            Scheduler.IntervalInSeconds(10, TaskIsRunning);

            Console.ReadLine();
        }

        private static void TaskIsRunning()
        {
            var books = PdfParser.GetAllParsedBooks(BookDir, BookService.IfBookExistsInDb);
            if (books.Any())
            {
                BookService.SaveBooksInDb(books.ToList());
                BookService.CreatePageTextIndex();
            }
            Console.WriteLine("Some books have been adding in db");
        }
    }
}

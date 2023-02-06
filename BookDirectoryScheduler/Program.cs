using System;
using System.Linq;
using Configuration;
using DataAccessLayer;

namespace BookDirectoryScheduler
{
    static class Program
    {
        private static readonly IBookService BookService = new BookService();
        private static readonly AppSettings AppSettings = new(new ConfigurationSource());
        
        static void Main(string[] args)
        {
            Console.WriteLine("Scheduler is running");
            //Starts every 10 seconds

            Scheduler.IntervalInSeconds(Convert.ToInt32(AppSettings.SchedulerIntervalSeconds), BooksParseTask);

            Console.ReadLine();
        }

        private static void BooksParseTask()
        {
            var pdfParser = new PdfParser();
            var books = pdfParser.GetAllParsedBooks(AppSettings.BooksDirectory);
            if (books.Any())
            {
                BookService.SaveBooksInDb(books.ToList());
                BookService.CreatePageTextIndex();
            }

            Console.WriteLine("Some books have been adding in db");
        }
    }
}
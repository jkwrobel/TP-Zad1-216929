using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookType
    {
        public BookType(string title, string author, int numberOfPages, float basePrice)
        {
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            BasePrice = basePrice;
            Guid = 101;
        }
        private int Guid { get; }
        private string Title { get; }
        private string Author { get; }
        private int NumberOfPages { get; }
        private float BasePrice { get; }
    }
}
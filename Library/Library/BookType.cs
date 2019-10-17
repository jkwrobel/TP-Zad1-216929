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
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
        public string Title { get; }
        public string Author { get; }
        public int NumberOfPages { get; }
        public float BasePrice { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookType
    {
        public BookType(Guid bookGuid, string title, string author, int numberOfPages)
        {
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            Guid = bookGuid;
        }
        public Guid Guid { get; }
        public string Title { get; }
        public string Author { get; }
        public int NumberOfPages { get; }
    }
}
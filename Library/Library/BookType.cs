using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseData
{
    public class BookType
    {
        public BookType(Guid bookBookGuid, string title, string author, int numberOfPages)
        {
            Title = title;
            Author = author;
            NumberOfPages = numberOfPages;
            BookGuid = bookBookGuid;
        }
        public Guid BookGuid { get; }
        public string Title { get; }
        public string Author { get; }
        public int NumberOfPages { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookUnit
    {
        public BookUnit(BookType book, int bookPrintNumber)
        {
            BookUnitGuid = Guid.NewGuid();
            Book = book;
            BookPrintNumber = bookPrintNumber;
            IsAvailable = true;
        }
        public BookType Book { get; }
        public Guid BookUnitGuid { get; }
        public int BookPrintNumber { get; }
        public bool IsAvailable { get; set; }
    }
}
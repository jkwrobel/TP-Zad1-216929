using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookUnit
    {
        public BookUnit(BookType bookGuid)
        {
            BookUnitGuid = Guid.NewGuid();
            Book = bookGuid;
            BookPrintNumber = Book.GetHashCode();
        }
        public BookType Book { get; }
        public Guid BookUnitGuid { get; }
        public int BookPrintNumber { get; }
    }
}
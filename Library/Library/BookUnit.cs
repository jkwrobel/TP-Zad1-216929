using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookUnit
    {
        public BookUnit(Guid guid, BookType book, int bookPrintNumber)
        {
            BookUnitGuid = guid;
            Book = book;
            BookPrintNumber = bookPrintNumber;
            IsAvailable = AvailableStatus.Yes;
        }
        public BookType Book { get; }
        public Guid BookUnitGuid { get; }
        public int BookPrintNumber { get; }
        public AvailableStatus IsAvailable { get; set; }

        public enum AvailableStatus
        {
            Yes = 0,
            Rented = 1,
            Destroyed = 2
        }
    }
}
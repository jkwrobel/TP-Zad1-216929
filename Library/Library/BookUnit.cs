using System;

namespace BaseData
{
    public class BookUnit
    {
        public BookUnit(Guid guid, BookType bookType, int bookPrintNumber)
        {
            BookUnitGuid = guid;
            BookType = bookType;
            BookPrintNumber = bookPrintNumber;
            IsAvailable = AvailableStatus.Yes;
        }
        public BookType BookType { get; }
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
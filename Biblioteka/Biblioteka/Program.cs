using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    internal abstract class AWykaz//Klient biblioteki - uzytkownik
    {
        public AWykaz()
        {
            UserUuid = 100;
        }
        private int UserUuid { get; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public abstract float ApplyDiscount(float Price);
    }

    class Student : AWykaz
    {
        public override float ApplyDiscount(float Price)
        {
            return Price * 0.4f;
        }
    }

    class Regular : AWykaz
    {
        public override float ApplyDiscount(float Price)
        {
            return Price;
        }
    }

    public class Katalog //Ksiazka opisuje jeden typ ksiazki
    {
        public Katalog()
        {
            Uuid = 101;
        }
        private int Uuid { get; }
        private string Title { get; set; }
        private string Author { get; set; }
        private int NumberOfPages { get; set; }
    }

    public class OpisStanu // Opis Ksiazki - opisuje konkretny egzemplarz
    {
        public OpisStanu(int bookUuid)
        {
            BookUuid = bookUuid;
            BookPrintNumber = BookUuid % 1000;
        }
        private int BookUuid { get; }
        private int BookStateUuid { get; }
        private int BookPrintNumber { get; }
        private float Price { get; set; }
    }

    public class Zdarzenie //Wypozyczenie
    {
        private Zdarzenie(int userUuid, int bookStateUuid, DateTime whenRented)
        {
            UserUuid = userUuid;
            BookStateUuid = bookStateUuid;
            WhenRented = whenRented;
            ExpectedReturnDate = whenRented.AddDays(14);
        }

        private int UserUuid { get; }
        private int BookStateUuid { get; }
        private DateTime WhenRented { get; }
        private DateTime ExpectedReturnDate { get; }
    }

    internal class DataRepository
    {
        public DataRepository(IDataFiller dataFiller)
        {
            dataFiller.Fill(data.Users, data.Books, data.BookStates, data.Rents);
        }

        private class DataContext
        {
            public List<AWykaz> Users;
            public Dictionary<int, Katalog> Books;
            public ObservableCollection<OpisStanu> BookStates;
            public ObservableCollection<Zdarzenie> Rents;
        }

        private DataContext data;
    }

    internal interface IDataFiller
    {
        void Fill(List<AWykaz> users, Dictionary<int, Katalog> books, ObservableCollection<OpisStanu> bookStates, ObservableCollection<Zdarzenie> rents);
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Book
    {
        private string _title;
        private int _price;

        public int Id { get; set; }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Titlen på bogen må ikke være tom");
                }
                if (value.Length < 3)
                {
                    throw new ArgumentException("Titlen skal være mindst 3 karakterer lang");
                }
                else
                {
                    _title = value;
                }
            }
        }
        public int Price 
        { 
            get
            {
                return _price;
            }
            set
            {
                if (value > 0 && value <= 1200) 
                { 
                    _price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Book(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        public Book()
        {

        }

        public override string ToString()
        {
            return $"Id: {Id}. Title: {Title}. Price: {Price}";
        }
    }
}

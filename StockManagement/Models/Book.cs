using System;
using System.Globalization;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace StockManagement.Models
{
    public enum BindingType
    {
        UNKNOWN,
        PAPERBACK,
        HARDCOVER,
        COALWOOD
    }

    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public bool InStock { get; set; }

        public BindingType Binding { get; set; }

        public string Description { get; set; }
    }

    public class BookMapping : CsvMapping<Book>
    {
        public BookMapping() : base()
        {
            MapProperty(0, x => x.Title);
            MapProperty(1, x => x.Author);
            MapProperty(2, x => x.Year);
            MapProperty(3, x => x.Price, new DecimalConverter(new CultureInfo("de-DE")));
            MapProperty(4, x => x.InStock, new BoolConverter("yes", "no", StringComparison.OrdinalIgnoreCase));
            MapProperty(5, x => x.Binding, new EnumConverter<BindingType>(true));
            MapProperty(6, x => x.Description);
        }
    }
}

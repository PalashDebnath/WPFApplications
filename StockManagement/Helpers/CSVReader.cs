using StockManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;

namespace StockManagement.Helpers
{
    public class CSVReader : IFileReader
    {
        public Task<IEnumerable<Book>> Read(string path)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ';');
            CsvParser<Book> csvParser = new CsvParser<Book>(csvParserOptions, new BookMapping());

            var result = csvParser.ReadFromFile(path, Encoding.UTF8) 
                                  .Where(r => r.IsValid)
                                  .Select(r => r.Result)
                                  .OrderByDescending(r => r.Price)
                                  .ToList();
            return Task.FromResult<IEnumerable<Book>>(result);
        }
    }
}

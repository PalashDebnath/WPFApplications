using StockManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Helpers
{
    public interface IFileReader
    {
        Task<IEnumerable<Book>> Read(string path);
    }
}

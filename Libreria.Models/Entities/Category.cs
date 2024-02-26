using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Libreria.Models.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; } = String.Empty;
        public ICollection<Book> books { get; set; } = null!;
    }
}

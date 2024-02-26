using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Libreria.Models.Entities
{
    public class Book
    {


        public int? id { get; set; }

        public string title { get; set; } = string.Empty;

        public string author { get; set; } = string.Empty;

        public string publisher { get; set; } = string.Empty;

        public DateTime relase { get; set; } = DateTime.Now;

        public ICollection<Category> categories { get; set; } = [];
    }
}

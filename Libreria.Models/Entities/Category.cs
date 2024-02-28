using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Libreria.Models.Entities
{
    public class Category
    {
        public int? id { get; set; }
        public string name { get; set; } = String.Empty;
        [JsonIgnore]
        public ICollection<Book>? books { get; set; } = null!;
    }
}

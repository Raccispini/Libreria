using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Libreria.Models.Entities
{
    public class BookCategory
    {
        [JsonIgnore]
        public int idBook {  get; set; }
        [JsonIgnore]
        public int idCategory { get; set; }
        [JsonIgnore]
        public Book book { get; set; } = null!;
        [JsonIgnore]
        public Category category { get; set; } = null!;
    }
}

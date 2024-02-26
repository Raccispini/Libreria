using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Libreria.Models.Entities
{
    public class User
    {
        public int id { get; set; }

        public string email { get; set; } = String.Empty;

        public string username { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;

        public string name { get; set; } = String.Empty;

        public string surname { get; set; } = String.Empty;
    }
}

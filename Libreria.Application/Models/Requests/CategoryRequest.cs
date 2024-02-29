using Libreria.Application.Abstractions;
using Libreria.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Libreria.Application.Models.Requests
{
    public class CategoryRequest : GeneralRequest<Category>
    {
        [Required]
        public int id { get; set; }
        public string? name { get; set; }=String.Empty;
        public Category ToEntity()
        {
            var category = new Category();
            category.id = id;
            category.name = name;
            return category;
        }
    }
}

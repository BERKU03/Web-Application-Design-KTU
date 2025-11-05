using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalLibrary.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public required string Description { get; set; }

        // Relación: Una categoría puede contener varios libros
         [JsonIgnore]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
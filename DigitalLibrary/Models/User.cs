using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalLibrary.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Role { get; set; } 

        // Relación: Un usuario puede tener varios libros favoritos
         [JsonIgnore]
        public List<Book> FavoriteBooks { get; set; } = new List<Book>();
    }

    public enum UserRole
    {
        Guest,
        Member,
        Administrator
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DigitalLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Author { get; set; } = string.Empty;

        // Descripción del libro
        public string Description { get; set; } = string.Empty;

        // Fecha de publicación (tipo DateTime es más correcto)
        public DateTime PublicationDate { get; set; }

        // Ruta o enlace al archivo del libro
        public string File { get; set; } = string.Empty;

        // Relación: un libro pertenece a una categoría
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Relación: un libro puede estar asociado a un usuario
        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace ERPWebApp.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "The phone number cannot exceed 20 characters.")]
        public string Phone { get; set; } = string.Empty;
    }
}

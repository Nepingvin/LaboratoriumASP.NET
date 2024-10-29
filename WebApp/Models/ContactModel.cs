using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ContactModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [MaxLength(length: 20, ErrorMessage = "More then 20 characters is not allowed")]
        [MinLength(length: 2, ErrorMessage = "Less then 20 characters is not allowed")]

        public string FirstName { get; set; }
        [Required]
        [MaxLength(length: 50, ErrorMessage = "More then 50 characters is not allowed")]
        [MinLength(length: 2, ErrorMessage = "Less then 20 characters is not allowed")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [RegularExpression(pattern: "\\d{3} \\d{3} \\d{3}", ErrorMessage = "Enter number like this: xxx xxx xxx")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

    }
}

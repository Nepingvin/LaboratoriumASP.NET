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
        [Display(Name = "Imię")]

        public string FirstName { get; set; }
        [Required]
        [MaxLength(length: 50, ErrorMessage = "More then 50 characters is not allowed")]
        [MinLength(length: 2, ErrorMessage = "Less then 20 characters is not allowed")]
        [Display(Name = "Nazwisko")]

        public string LastName { get; set; }
        [EmailAddress]
        [Display(Name = "Adres e-mail")]

        public string Email { get; set; }
        [Phone]
        [RegularExpression(pattern: "\\d{3} \\d{3} \\d{3}", ErrorMessage = "Enter number like this: xxx xxx xxx")]
        [Display(Name = "Numer telefonu")]

        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]

        public DateOnly BirthDate { get; set; }

        [Display(Name = "Kategoria")]

        public Category Category { get; set; }

    }
}

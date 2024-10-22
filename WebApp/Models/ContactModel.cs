using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }

    [Required]
    [MaxLength (length: 20, ErrorMessage = "Imie nie moze byc wieksze niz 20 znakiow")]
    [MinLength (length: 2, ErrorMessage = "Imie musi miec co najmniej 2 znaki")]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength (length: 50, ErrorMessage = "Imie nie moze byc wieksze niz 20 znakiow")]
    [MinLength (length: 2, ErrorMessage = "Imie musi miec co najmniej 2 znaki")]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression(pattern: "\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wg wzoru xxx xxx xxx")]
    public string PhoneNumber { get; set; }
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
}
namespace WebApp.Models;
using System.ComponentModel.DataAnnotations;

public enum Category
{
    [Display(Name = "Rodzina", Order = 1)]
    Family,
    [Display(Name = "Znajomi", Order = 3)]
    Friend,
    [Display(Name = "Kontakty zawodowe", Order = 2)]
    Business
}
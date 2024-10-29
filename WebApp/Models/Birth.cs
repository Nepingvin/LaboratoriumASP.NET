using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Birth
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name {  get; set; }
        [Required(ErrorMessage = "Birth Date is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool isValid()
        {
            if(DateTime.TryParse(BirthDate.ToString(), out DateTime result) && result < DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public int CalculateAge()
        {

            DateTime today = DateTime.Now;

            int years = today.Year - BirthDate.Year;

            if (BirthDate.Date > today.AddYears(-years).Date)
            {
                years--;
            }
            return years;
        }
    }
}

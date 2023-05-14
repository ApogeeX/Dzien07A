using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class Member
    {
        [Required(ErrorMessage ="Podaj nazwę")]
        //[MinLength(5, ErrorMessage ="Nazwa musi mieć co najmniej 5 znaków")]
        //[MaxLength(15, ErrorMessage ="Nazwa nie może mieć wiecej niż 15 znaków")]
        [StringLength(25, MinimumLength = 3, ErrorMessage ="Nazwa musi mieć między 3 a 25 znaków")]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Url]
        public string Url { get; set; } = "";

        [Required]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Kod pocztowy w formacie XX-XXX")]
        public string? ZipCode { get; set; } = "";

        //[Range(15,55, ErrorMessage = "Wiek musi być w zakresie 15-55")]
        [AgeOver(18)]
        public int Age { get; set; }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CallClient2023Web.Models
{
    public class BazaBrojeva
    {
        [Required]
        
        [Display(Name ="Ime i Prezime")]
        public string? ImePrezime { get; set; }

        [Required]
        [Key]
        [Display(Name ="Broj telefona")]
        public int BrojTelefona { get; set; }

        [Required]
        [Display(Name ="Adresa stanovanja")]
        public string? AdresaStanovanja { get; set; }


        [Display(Name = "Asortiman")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? AsortimanProizvoda { get; set; } = string.Empty;

        
        [Display(Name = "Proizvod")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? Proizvod { get; set; } = string.Empty;



        [Display(Name = "Komada")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? BrojKomada { get; set; } = string.Empty;


        [Display(Name = "Članstvo")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? Clanstvo {  get; set; } = string.Empty;
    }
}

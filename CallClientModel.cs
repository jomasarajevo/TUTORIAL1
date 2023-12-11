using System.ComponentModel.DataAnnotations;

namespace CallClient2023Web.Models
{
    public class CallClientModel
    {
        [Key]
        [Required]
        public int CallId { get; set; }

        [Required]
        [Display(Name ="Survey Code")]
        public int KodAnkete { get; set; }

        [Required]
        [Display(Name = "Survey Pass")]
        public string KodAnketara { get; set; }
    }
}

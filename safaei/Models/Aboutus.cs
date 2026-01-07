using System.ComponentModel.DataAnnotations;

namespace safaei.Models
{
    public class Aboutus
    {
        [Key]
        public int AboutusId { get; set; }



        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int tell { get; set; }



        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        public string addrees { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace safaei.Models
{
    public class contactus
    {
        [Key]
        public int contactId { get; set; }



        [Display(Name = " تلفن")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int tell { get; set; }


        [Display(Name = " موبایل")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Mobile { get; set; }
    }
}

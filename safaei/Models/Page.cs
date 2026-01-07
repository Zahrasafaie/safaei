using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace safaei.Models
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }


        [Display(Name = "گروه خبری")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int GroupId { get; set; }




        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        public String Title { get; set; }



        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        [DataType(DataType.MultilineText)]
        public String ShortDescription { get; set; }



        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        [DataType(DataType.MultilineText)]
        public String Text { get; set; }



        [Display(Name = "بازدید")]
        public int Visit { get; set; }




        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }



        [Display(Name = "تصویر")]
        public String ImageName { get; set; }



        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreatDate { get; set; }


        #region Relational
        [ForeignKey("GroupId")]
        public virtual PageGroup PageGroup { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        #endregion
    }
}

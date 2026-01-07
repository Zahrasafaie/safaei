using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace safaei.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }


        //[Display(Name = "صفحه محصولات")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int PageId { get; set; }



        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        public string Name { get; set; }



        [Display(Name = " Email ایمیل")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        public string Email { get; set; }




        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        public string comment { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}")]
        public DateTime CreatData { get; set; }




        #region Relational
        [ForeignKey("PageId")]
        public virtual Page page { get; set; }
        #endregion
    }
}


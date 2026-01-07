using System.ComponentModel.DataAnnotations;

namespace safaei.Models
{
    public class PageGroup
    {
        [Key]
        public int GroupId { get; set; }


        
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0}نباید بیشتر از{1}کاراکترباشد")]
        public String GroupTitle { get; set; }



        #region Relational
        public virtual ICollection<Page> Page { get; set; }
       
        #endregion
    }
}

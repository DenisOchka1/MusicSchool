using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.Data
{
    public class User_Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Идентификатор")]
        public short Id { get; set; }

        [Display(Name = "Email")]
        public string? IdUser { get; set; }

        //Навигационные свойства
        [Display(Name = "Email")]
        [ForeignKey("IdUser")]
        public User User { get; set; }

        [Display(Name = "Курс")]
        public short? IdCourse { get; set; }

        //Навигационные свойства
        [Display(Name = "Курс")]
        [ForeignKey("IdCourse")]
        public Course Course { get; set; }

      
        [Display(Name = "Дата покупки курса")]
        public DateTime DateOfPurchase { get; set; }

        [Display(Name = "Отзыв")]
        public string? Review { get; set; }

        [Display(Name = "Дата отзыва")]
        public DateTime? DateReview { get; set; }
    }
}

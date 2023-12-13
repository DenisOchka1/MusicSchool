using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.Data
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Идентификатор")]

        public short Id { get; set; }

        [Required(ErrorMessage = "Введите название курса")]
        [Display(Name = "Название курса")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Введите название описание курса")]
        [Display(Name = "Описание")]
        public string CourseDescr { get; set; }

        [Required(ErrorMessage = "Введите количество уроков")]
        [Display(Name = "Количество уроков")]
        public int CountLesson { get; set; }

        //[Required]
        public string? IdUser { get; set;}

        //Навигационные свойства

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}

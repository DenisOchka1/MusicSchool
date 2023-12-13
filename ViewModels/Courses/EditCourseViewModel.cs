using System.ComponentModel.DataAnnotations;

namespace MusicSchool.ViewModels.Courses
{
    public class EditCourseViewModel
    {
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
    }
}

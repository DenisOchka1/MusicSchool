using System.ComponentModel.DataAnnotations;

namespace MusicSchool.ViewModels.UsersCourses
{
    public class CreateUserCourseViewModel
    {
        [Display(Name = "Отзыв")]
        public string? Review { get; set; }

        [Display(Name = "Email")]
        public string? IdUser { get; set; }

        [Display(Name = "Курс")]
        public short? IdCourse { get; set; }
    }
}

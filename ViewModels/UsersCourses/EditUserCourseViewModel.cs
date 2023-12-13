using System.ComponentModel.DataAnnotations;

namespace MusicSchool.ViewModels.UsersCourses
{
    public class EditUserCourseViewModel
    {
        public short Id { get; set; }


        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Курс")]
        public string? CourseName { get; set; }

        [Display(Name = "Отзыв")]
        public string? Review { get; set; }
    }
}

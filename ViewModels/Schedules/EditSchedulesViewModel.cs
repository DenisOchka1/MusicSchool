using System.ComponentModel.DataAnnotations;

namespace MusicSchool.ViewModels.Schedules
{
    public class EditSchedulesViewModel
    {
        public short Id { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Курс")]
        public string? CourseName { get; set; }

        //Навигационные свойства

        [Display(Name = "Время начала занятия")]
        public DateTime ClassStartTime { get; set; }

        [Display(Name = "Время окончания занятия")]
        public DateTime ClassEndTime { get; set; }
    }
}

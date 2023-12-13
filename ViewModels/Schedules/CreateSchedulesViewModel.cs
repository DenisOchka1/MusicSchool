using System.ComponentModel.DataAnnotations;

namespace MusicSchool.ViewModels.Schedules
{
    public class CreateSchedulesViewModel
    {
        [Display(Name = "Преподаватель")]
        public string? IdUser { get; set; }


        [Display(Name = "Курс")]
        public short? IdCourse { get; set; }


        [Display(Name = "Время начала занятия")]
        public DateTime ClassStartTime { get; set; }

        [Display(Name = "Время окончания занятия")]
        public DateTime ClassEndTime { get; set; }


    }
}

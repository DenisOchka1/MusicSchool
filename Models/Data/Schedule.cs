using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicSchool.Models.Data
{
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Идентификатор")]

        public short Id { get; set; }

        public string? IdUser { get; set; }

        //Навигационные свойства
        [Display(Name = "Email")]
        [ForeignKey("IdUser")]
        public User User { get; set; }

        public short? IdCourse { get; set; }

        //Навигационные свойства
        [Display(Name = "Курс")]
        [ForeignKey("IdCourse")]
        public Course Course { get; set; }


        [Display(Name = "Время начала занятия")]
        public DateTime ClassStartTime { get; set; }

        [Display(Name = "Время окончания занятия")]
        public DateTime ClassEndTime { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSchool.Models.Data
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Введите фамилию")]

        //отображение Фамилия вместо LastName
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
                
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }

        [Display(Name = "Дата регистрации")]
        public string? DateReg { get; set; }
                
        [Display(Name = "Дата приёма на работу")]
        public string? DateWorking { get; set; }
        
        [Display(Name = "Дата увольнения")]
        public string? DateDismissal { get; set; }

    }
}

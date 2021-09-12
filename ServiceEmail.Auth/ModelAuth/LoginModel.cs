using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.Auth.ModelAuth
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Не указан Email")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "Не указан пароль")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; } = "/Account/Login";

    }
}

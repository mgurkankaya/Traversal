﻿using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı girin!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi girin!")]
        public string password { get; set; }
    }
}

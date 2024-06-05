using System.ComponentModel.DataAnnotations;

namespace Traversal.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen adınızı girin")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen soyadınızı girin")]
		public string Surname { get; set; }

		[Required(ErrorMessage = "Lütfen Kullanıcı adınızı girin")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen mail adresinizi girin")]
		public string Mail { get; set; }


		[Required(ErrorMessage = "Lütfen şifrenizi girin")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi tekrar girin")]
		[Compare("Password", ErrorMessage ="Şifreler uyuşmadı.")]
		public string ConfirmPassword { get; set; }
	}
}

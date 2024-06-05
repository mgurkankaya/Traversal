using Microsoft.AspNetCore.Identity;

namespace Traversal.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Parola minimun {length} karakter olmalıdır!"
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresUpper",
				Description = "Parola en az 1 BÜYÜK harf içermelidir!"
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresLower",
				Description = "Parola en az 1 küçük harf içermelidir!"
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresDigit",
				Description = "Parola en az 1 rakam (0-9) harf içermelidir!"
			};
		}

		public override IdentityError PasswordMismatch()
		{
			return new IdentityError()
			{
				Code = "PasswordMismatch",
				Description = "Girilen şifreler birbirleriyle eşleşmiyor."
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Parola en az bir sembol (Örn: *?/& vb) karakter içermelidir!"
			};
		}
	}
}

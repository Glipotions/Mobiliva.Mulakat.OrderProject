using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
	public static class ValidationTool
	{
		/// <summary>
		/// Doğrulama yapmayı sağlar. gelen entitynin istenilen validate kurallarına uyup uymadığını kontrol eder.
		/// </summary>
		public static void Validate(IValidator validator, object entity)
		{
			var context = new ValidationContext<object>(entity);
			var result = validator.Validate(context);
			if (!result.IsValid) //doğrulanmazsa hata ver komutu
			{
				throw new ValidationException(result.Errors);
			}

		}

	}
}

using FluentValidation;
using Sat.Recruitment.Dto;
using Sat.Recruitment.Dto.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Extensions
{
    public static class CreateValidatorExtensions
    {
        public static async Task<ValidatorDto> CustomValidateAsync(this AbstractValidator<CreateUserDto> validator, CreateUserDto createUserDto)
        {
            var ValidateResult = await validator.ValidateAsync(createUserDto);

            var result = new ValidatorDto()
            {
                IsValid = ValidateResult.IsValid
            };

            if (!ValidateResult.IsValid)
            {
                result.Errors = new List<string>();

                foreach (var item in ValidateResult.Errors)
                {
                    result.Errors.Add(item.ErrorMessage);
                }
            }

            return result;
        }
    }
}

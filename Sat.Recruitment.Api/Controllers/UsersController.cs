using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Extensions;
using Sat.Recruitment.Api.Validators;
using Sat.Recruitment.Dto.Request;
using Sat.Recruitment.Dto.Response;
using Sat.Recruitment.Service;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ResultDto> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            CreateUserValidator validator = new CreateUserValidator();
            var ValidateResult = await validator.CustomValidateAsync(createUserDto);

            if (!ValidateResult.IsValid)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Errors = ValidateResult.Errors
                };
            }
            var result = await _userService.CreateUser(createUserDto);

            return result;
        }
    }
}

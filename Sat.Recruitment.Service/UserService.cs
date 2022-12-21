using Sat.Recruitment.Domain;
using Sat.Recruitment.Dto;
using Sat.Recruitment.Dto.Request;
using Sat.Recruitment.Dto.Response;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Service.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    public class UserService : IUserService
    {
        private readonly IMoneyService _moneyService;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IMoneyService moneyService)
        {
            _userRepository = userRepository;
            _moneyService = moneyService;
        }

        public async Task<ResultDto> CreateUser(CreateUserDto createUserDto)
        {
            ResultDto response = new ResultDto();

            string NormalizedEmail = EmailHelper.NormalizeEmail(createUserDto.Email);

            var calculatedMoneyTask = _moneyService.GetUserMoneyFromQuantityAndUserType(createUserDto.Money, createUserDto.UserType);
            var SavedUsersTask = _userRepository.GetUsers();

            await Task.WhenAll(calculatedMoneyTask, SavedUsersTask);

            var calculatedMoney = calculatedMoneyTask.Result;
            var SavedUsers = SavedUsersTask.Result;

            bool isDuplicated = false;

            UserDto userAux = null;

            userAux = SavedUsers.Where(u => u.Email == createUserDto.Email || u.Phone == createUserDto.Phone).FirstOrDefault();

            if (userAux != null)
            {
                isDuplicated = true;
            }

            if (!isDuplicated)
            {
                userAux = SavedUsers.Where(u => u.Name == createUserDto.Name && u.Address== createUserDto.Address).FirstOrDefault();

                if (userAux != null)
                {
                    isDuplicated = true;
                }
            }

            if (!isDuplicated)
            {
                UserDto newUser = new UserDto()
                {
                    Money = calculatedMoney,
                    Address = createUserDto.Address,
                    Email = createUserDto.Email,
                    UserType = createUserDto.UserType,
                    Name = createUserDto.Name,
                    Phone = createUserDto.Phone
                };
                response.IsSuccess = true;
                response.Message = "User created";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "User was not created";
                response.Errors = new List<string>()
                {
                    "The user is duplicated"
                };
            }

            return response;
        }
    }
}

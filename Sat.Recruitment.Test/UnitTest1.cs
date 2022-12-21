using System.Linq;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Dto.Enumerators;
using Sat.Recruitment.Dto.Request;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Service;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        private static IUserRepository userRepository = new UserRepository();
        private static IMoneyService moneyService = new MoneyService();
        private static IUserService userService = new UserService(userRepository, moneyService);

        [Fact]
        public async Task Test1()
        {
            var userController = new UsersController(userService);

            CreateUserDto createUserDto = new CreateUserDto()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserTypeEnum.Normal,
                Money = 124
            };

            var result = await userController.CreateUser(createUserDto);

            Assert.True(result.IsSuccess);
            Assert.Equal("User created", result.Message);
        }

        [Fact]
        public async Task Test2()
        {
            var userController = new UsersController(userService);

            CreateUserDto createUserDto = new CreateUserDto()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = UserTypeEnum.Normal,
                Money = 124
            };

            var result = await userController.CreateUser(createUserDto);

            Assert.False(result.IsSuccess);
            Assert.Equal("User was not created", result.Message);
            Assert.Equal("The user is duplicated", result.Errors.Where(e => e == "The user is duplicated").FirstOrDefault());
        }
    }
}

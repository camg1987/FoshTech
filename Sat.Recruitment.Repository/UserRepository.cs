using Sat.Recruitment.Domain;
using Sat.Recruitment.Dto;
using Sat.Recruitment.Dto.Enumerators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<UserDto>> GetUsers()
        {
            return await Task.Run(() =>
            {
                List<UserDto> userDtos = new List<UserDto>();
                List<User> users = new List<User>();
                var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };
                    users.Add(user);
                }

                users.ForEach(u => 
                {
                    UserTypeEnum userType = (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), u.UserType);
                    userDtos.Add(new UserDto()
                    {
                        Name = u.Name,
                        Address = u.Address,
                        Email = u.Email,
                        Money = u.Money,
                        Phone = u.Phone,
                        UserType = userType
                    });
                });

                return userDtos;
            });
        }
    }
}

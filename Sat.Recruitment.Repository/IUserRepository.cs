using Sat.Recruitment.Domain;
using Sat.Recruitment.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetUsers();
    }
}

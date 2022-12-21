using Sat.Recruitment.Dto.Request;
using Sat.Recruitment.Dto.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    public interface IUserService
    {
        Task<ResultDto> CreateUser(CreateUserDto createUserDto);
    }
}

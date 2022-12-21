using Sat.Recruitment.Dto.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    public interface IMoneyService
    {
        Task<decimal> GetUserMoneyFromQuantityAndUserType(decimal money,UserTypeEnum userTypeEnum);
    }
}

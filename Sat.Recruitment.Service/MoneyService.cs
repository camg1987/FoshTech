using Sat.Recruitment.Dto.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service
{
    public class MoneyService : IMoneyService
    {
        public async Task<decimal> GetUserMoneyFromQuantityAndUserType(decimal money, UserTypeEnum userTypeEnum)
        {
            return await Task.Run(() =>
            {
                decimal calculatedMoney = 0;

                if (userTypeEnum == UserTypeEnum.Normal)
                {
                    if (money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.12);
                        var gif = money * percentage;
                        calculatedMoney = money + gif;
                    }
                    if (money < 100)
                    {
                        if (money > 10)
                        {
                            var percentage = Convert.ToDecimal(0.8);
                            var gif = money * percentage;
                            calculatedMoney = money + gif;
                        }
                    }
                }

                if (userTypeEnum == UserTypeEnum.SuperUser)
                {
                    if (money > 100)
                    {
                        var percentage = Convert.ToDecimal(0.20);
                        var gif = money * percentage;
                        calculatedMoney = money + gif;
                    }
                }

                if (userTypeEnum == UserTypeEnum.Premium)
                {
                    if (money > 100)
                    {
                        var gif = money * 2;
                        calculatedMoney = money + gif;
                    }
                }

                return calculatedMoney;
            });
        }
    }
}

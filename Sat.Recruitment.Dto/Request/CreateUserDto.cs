using Sat.Recruitment.Dto.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Dto.Request
{
    public class CreateUserDto
    {
        public string Name;
        public string Email;
        public string Address;
        public string Phone;
        public UserTypeEnum UserType;
        public decimal Money;
    }
}

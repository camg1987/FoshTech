using Sat.Recruitment.Dto.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserTypeEnum UserType { get; set; }
        public decimal Money { get; set; }
    }
}

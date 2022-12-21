using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Dto
{
    public class ValidatorDto
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
    }
}

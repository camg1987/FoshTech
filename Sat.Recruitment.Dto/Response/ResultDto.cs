using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Dto.Response
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}

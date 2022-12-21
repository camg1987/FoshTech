using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Service.Helpers
{
    public class EmailHelper
    {
        public static string NormalizeEmail(string Email)
        {
            string normalizedEmail = string.Empty;

            var aux = Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            normalizedEmail = string.Join("@", new string[] { aux[0], aux[1] });

            return normalizedEmail;
        }
    }
}

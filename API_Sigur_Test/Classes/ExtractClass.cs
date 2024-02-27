using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API_Sigur_Test
{
    internal class ExtractClass
    {
        public static string ExtractTokenValue(string jsonString) // Метод получения токена из json
        {
            string pattern = "\"token\":\"(.*?)\"";
            Match match = Regex.Match(jsonString, pattern);

            if (match.Success && match.Groups.Count > 1)
            {
                return match.Groups[1].Value;
            }
            return null;
        }
        public static string ExtractUsernameValue(string jsonString) // Метод получения имени сотрудника из json
        {
            string pattern = "\"username\":\"(.*?)\"";
            Match match = Regex.Match(jsonString, pattern);

            if (match.Success && match.Groups.Count > 1)
            {
                return match.Groups[1].Value;
            }
            return null;
        }
    }
}

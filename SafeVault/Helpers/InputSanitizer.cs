using System.Text.RegularExpressions;

namespace SafeVault.Helpers
{
    
    public static class InputSanitizer
    {
        public static string SanitizeUsername(string input)
        {
            //return Regex.Replace(input ?? "", @"[^\w]", "");
            //return Regex.Replace(input ?? "", @"^[a-zA-Z0-9@.]+$","");
            return Regex.Replace(input ?? "", @"[^a-zA-Z0-9_.]", "");


        }

        public static string SanitizeEmail(string input)
        {
            
            return Regex.Replace(input ?? "", @"[^\w@.-]", "");

        }
    }

}

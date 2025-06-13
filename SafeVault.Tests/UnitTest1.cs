
using NUnit.Framework;
using SafeVault.Helpers;
using SafeVault.Models;

namespace SafeVault.Tests
{
    public class TestInputValidation
    {
        [Test]
        public void TestForSQLInjection()
        {
            string malicious = "'; DROP TABLE Users; --";
            string sanitized = InputSanitizer.SanitizeUsername(malicious);
            Assert.False(sanitized.Contains("DROP") || sanitized.Contains(";"), "SQL keyword was not removed");
        }

        [Test]
        public void TestForXSS()
        {
            string script = "<script>alert('xss');</script>";
            string sanitized = InputSanitizer.SanitizeUsername(script);
            Assert.False(sanitized.Contains("<") || sanitized.Contains(">") || sanitized.Contains("script"));
        }

        



    }
}

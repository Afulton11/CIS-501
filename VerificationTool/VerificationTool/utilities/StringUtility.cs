using System.Text;

namespace VerificationTool.utilities
{
    public static class StringUtility
    {

        public static string AddLine(string s, string line) =>
            new StringBuilder(s).AppendLine(line).ToString();
    }
}

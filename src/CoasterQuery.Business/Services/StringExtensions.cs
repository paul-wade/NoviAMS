namespace CoasterQuery.Business.Services
{
    public static class StringExtensions
    {
        public static string CleanSpaces(this string input)
        {
            return input.Replace(' ', '+');
        }
    }

}
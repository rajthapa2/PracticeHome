namespace Pipeline
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var chars = name.ToCharArray();
                chars[0] = char.ToLower(chars[0]);
                return new string(chars);
            }
            return name;
        }
    }
}
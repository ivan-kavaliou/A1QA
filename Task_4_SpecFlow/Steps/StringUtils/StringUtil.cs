namespace Steps.StringUtils
{
    public static class StringUtil
    {
        public static string TransformStringToLowerWithoutSpecSymbols(string[] str)
        {
            var resaultTransformString = string.Join("", str).Replace(" ", "").Replace("-", "").ToLower();

            return resaultTransformString;
        }
    }
}
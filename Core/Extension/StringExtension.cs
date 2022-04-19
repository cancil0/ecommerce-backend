namespace Core.Extension
{
    public static class StringExtension
    {
        public static short ToShort(this string item)
        {
            return (short)(short.TryParse(item, out var result) ? result : 0);
        }
        public static int ToInt(this string item)
        {
            return int.TryParse(item, out var result) ? result : 0;
        }
        public static long ToLong(this string item)
        {
            return long.TryParse(item, out var result) ? result : 0;
        }
        
        public static string Nullify(this string item)
        {
            return string.IsNullOrEmpty(item) ? null : item;
        }

        public static string TurkishCharacterChange(this string word)
        {
            if (string.IsNullOrEmpty(word))
                return word;

            word = word.Replace("ğ", "g")
                       .Replace("Ğ", "G")
                       .Replace("Ü", "U")
                       .Replace("ü", "u")
                       .Replace("Ş", "S")
                       .Replace("ş", "s")
                       .Replace("Ç", "C")
                       .Replace("ç", "c")
                       .Replace("Ö", "O")
                       .Replace("ö", "o")
                       .Replace("İ", "I")
                       .Replace("ı", "i");
            return word;
        }
    }
}

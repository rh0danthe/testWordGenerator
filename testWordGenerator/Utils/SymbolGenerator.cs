using System.Collections.Generic;

namespace testWordGenerator.Utils
{
    public class SymbolGenerator
    {
        public static void GetRussianLowercaseCharacters(List<char> items)
        {
            for (char ch = 'а'; ch <= 'я'; ch++)
            {
                items.Add(ch);
            }
        }

        public static void GetEnglishLowercaseCharacters(List<char> items)
        {
            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                items.Add(ch);
            }
        }
        
        public static void GetRussianUppercaseCharacters(List<char> items)
        {
            for (char ch = 'А'; ch <= 'Я'; ch++)
            {
                items.Add(ch);
            }
        }

        public static void GetEnglishUppercaseCharacters(List<char> items)
        {
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                items.Add(ch);
            }
        }
    }
}
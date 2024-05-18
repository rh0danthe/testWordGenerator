using System.Collections.Generic;

namespace testWordGenerator.Utils
{
    /// <summary>
    /// Фабрика символов для русского и английского алфавитов.
    /// </summary>
    public static class CharListFactory 
    {
        /// <summary>
        /// Возвращает перечисление русских символов.
        /// </summary>
        /// <param name="uppercase">Указывает, должны ли возвращаться прописные символы.</param>
        /// <returns>Перечисление русских символов.</returns>
        public static IEnumerable<char> GetRussianCharacters(bool uppercase)
        {
            for (char ch = 'А'; ch <= 'Я'; ch++)
            {
                if (!uppercase) yield return (char)(ch + 'а' - 'А');
                else yield return ch;
            }
        }

        /// <summary>
        /// Возвращает перечисление английских символов.
        /// </summary>
        /// <param name="uppercase">Указывает, должны ли возвращаться прописные символы.</param>
        /// <returns>Перечисление английских символов.</returns>
        public static IEnumerable<char> GetEnglishCharacters(bool uppercase)
        {
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                if (!uppercase) yield return (char)(ch + 'a' - 'A');
                else yield return ch;
            }
        }
    }
}
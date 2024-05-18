using System.Collections.Generic;
using System.Linq;
using testWordGenerator.Utils;
using Xunit;

namespace testWordGeneratorTests.UtilsTests
{
    /// <summary>
    /// Тесты для класса CharListFactory.
    /// </summary>
    public class CharListFactoryTests
    {
        /// <summary>
        /// Проверяет, что метод GetRussianCharacters возвращает алфавит.
        /// </summary>
        /// <param name="uppercase">Флаг указывающий, являются ли символы заглавными.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetRussianCharacters_ReturnsAlphabet(bool uppercase)
        {
            // Arrange
            char startChar = uppercase ? 'А' : 'а';
            char endChar = uppercase ? 'Я' : 'я';

            // Act
            IEnumerable<char> russianCharacters = CharListFactory.GetRussianCharacters(uppercase);
            List<char> characterList = russianCharacters.ToList();

            // Assert
            for (char ch = startChar; ch <= endChar; ch++)
            {
                Assert.Contains(ch, characterList);
            }
        }

        /// <summary>
        /// Проверяет, что метод GetEnglishCharacters возвращает алфавит.
        /// </summary>
        /// <param name="uppercase">Флаг указывающий, являются ли символы заглавными.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GetEnglishCharacters_ReturnsAlphabet(bool uppercase)
        {
            // Arrange
            char startChar = uppercase ? 'A' : 'a';
            char endChar = uppercase ? 'Z' : 'z';

            // Act
            IEnumerable<char> englishCharacters = CharListFactory.GetEnglishCharacters(uppercase);
            List<char> characterList = englishCharacters.ToList();

            // Assert
            for (char ch = startChar; ch <= endChar; ch++)
            {
                Assert.Contains(ch, characterList);
            }
        }
    }
}
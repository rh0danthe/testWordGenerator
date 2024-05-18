using System.Collections.Generic;
using System.Linq;
using testWordGenerator.Models;
using Xunit;
using testWordGenerator.Services;
using testWordGenerator.Utils;

namespace testWordGeneratorTests.ServicesTests
{
    /// <summary>
    /// Тесты для класса WordService.
    /// </summary>
    public class WordServiceTests
    {
        private readonly WordService _wordService = WordService.GetInstance();
        
        /// <summary>
        /// Проверяет, что метод GenerateWords возвращает список слов.
        /// </summary>
        [Fact]
        public void GenerateWords_ReturnsListOfWords()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 5,
                MinLength = 5,
                MaxLength = 10,
                NumPercent = 30,
                LetterPercent = 60,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            var words = _wordService.GenerateWords(mask);

            // Assert
            Assert.Equal(5, words.Count);
            Assert.IsType<List<Word>>(words);
        }
        
        /// <summary>
        /// Проверяет, что метод GenerateWords возвращает слова в заданном диапазоне длин.
        /// </summary>
        [Fact]
        public void GenerateWords_ReturnsWordsWithinSpecifiedLengthRange()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 5,
                MinLength = 5,
                MaxLength = 10,
                NumPercent = 30,
                LetterPercent = 60,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            var words = _wordService.GenerateWords(mask);

            // Assert
            foreach (var word in words)
            {
                Assert.InRange(word.Content.Length, mask.MinLength, mask.MaxLength);
            }
        }

        /// <summary>
        /// Проверяет, что генератор возвращает строки с ожидаемыми типами символов.
        /// </summary>
        [Fact]
        public void Generator_ReturnsStringWithExpectedCharacterTypes()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 5,
                MinLength = 5,
                MaxLength = 10,
                NumPercent = 30,
                LetterPercent = 60,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };


            // Act
            var result = _wordService.GenerateWords(mask);

            // Assert
            foreach (var word in result)
            {
                var numCount = word.Content.Count(c => mask.Numbers.Items.Contains(c));
                var letterCount = word.Content.Count(c => mask.Letters.Items.Contains(c));
                var symbolCount = word.Content.Count(c => mask.Symbols.Items.Contains(c));
                var totalCount = word.Content.Length;

                var expectedNumCount = (int)(totalCount * mask.NumPercent / 100.0);
                var expectedLetterCount = (int)(totalCount * mask.LetterPercent / 100.0);

                Assert.True(numCount > 0 || letterCount > 0 || symbolCount > 0);
                Assert.Equal(expectedNumCount, numCount);
                Assert.Equal(expectedLetterCount, letterCount);
            }
        }
    }
}
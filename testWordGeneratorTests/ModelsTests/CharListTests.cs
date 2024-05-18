using System.Collections.Generic;
using testWordGenerator.Models;
using Xunit;

namespace testWordGeneratorTests.ModelsTests
{
    /// <summary>
    /// Тесты для класса CharList.
    /// </summary>
    public class CharListTests
    {
        /// <summary>
        /// Проверяет, что конструктор с указанными элементами устанавливает элементы корректно.
        /// </summary>
        [Fact]
        public void Constructor_WithItems_SetsItemsCorrectly()
        {
            // Arrange
            var items = new List<char> { 'a', 'b', 'c' };

            // Act
            var charList = new CharList(items);

            // Assert
            Assert.Equal(items, charList.Items);
        }

        /// <summary>
        /// Проверяет, что конструктор без элементов инициализирует пустой список.
        /// </summary>
        [Fact]
        public void Constructor_WithoutItems_InitializesEmptyList()
        {
            // Act
            var charList = new CharList();

            // Assert
            Assert.Empty(charList.Items);
        }

        /// <summary>
        /// Проверяет, что метод Add с одним символом добавляет символ в список.
        /// </summary>
        /// <param name="ch">Символ для добавления.</param>
        [Theory]
        [InlineData('a')]
        public void Add_SingleCharacter_AddsCharacterToList(char ch)
        {
            // Arrange
            var charList = new CharList();

            // Act
            charList.Add(ch);

            // Assert
            Assert.Contains(ch, charList.Items);
        }

        /// <summary>
        /// Проверяет, что метод AddRange с параметрами добавляет символы в список.
        /// </summary>
        /// <param name="chars">Символы для добавления.</param>
        [Theory]
        [InlineData(new char[]{'a', 'b', 'c'})]
        public void AddRange_Params_AddsCharactersToList(params char[] chars)
        {
            // Arrange
            var charList = new CharList();

            // Act
            charList.AddRange(chars);

            // Assert
            Assert.Equal(chars, charList.Items);
        }

        /// <summary>
        /// Проверяет, что метод AddRange с CharList добавляет символы из другого CharList.
        /// </summary>
        [Fact]
        public void AddRange_CharList_AddsCharactersFromAnotherCharList()
        {
            // Arrange
            var sourceList = new CharList(new List<char> { 'a', 'b', 'c' });
            var charList = new CharList();

            // Act
            charList.AddRange(sourceList);

            // Assert
            Assert.Equal(new List<char> { 'a', 'b', 'c' }, charList.Items);
        }
    }
}
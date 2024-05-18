using System.Collections.Generic;
using testWordGenerator.Models;
using testWordGenerator.Validators;
using Xunit;

namespace testWordGeneratorTests.ValidatorTests
{
    /// <summary>
    /// Тесты для класса MaskValidator.
    /// </summary>
    public class MaskValidatorTests
    {
        private readonly MaskValidator _validator = new MaskValidator();

        /// <summary>
        /// Проверяет, что метод IsValid возвращает true, когда параметры маски корректны.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsTrue_WhenMaskParametersAreValid()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 3,
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
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.True(isValid);
        }

        /// <summary>
        /// Проверяет, что метод IsValid возвращает false, когда количество слов в маске равно нулю.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenMaskCountIsZero()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 0,
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
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Проверяет, что метод IsValid возвращает false, когда минимальная длина в маске равна нулю.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenMinLengthIsZero()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 10,
                MinLength = 0,
                MaxLength = 10,
                NumPercent = 30,
                LetterPercent = 60,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Проверяет, что метод IsValid возвращает false, когда процент чисел  в маске меньше или равен нулю.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenNumPercentIsZeroOrLess()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 10,
                MinLength = 3,
                MaxLength = 10,
                NumPercent = -3,
                LetterPercent = 60,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Проверяет, возвращает ли метод IsValid значение false, когда все проценты равны нулю.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenAllPercentsAreZero()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 10,
                MinLength = 3,
                MaxLength = 10,
                NumPercent = 0,
                LetterPercent = 0,
                SymbolPercent = 0,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Проверяет, возвращает ли метод IsValid значение false, когда MaxLength меньше MinLength.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenMaxLessThanMinLength()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 5,
                MinLength = 5,
                MaxLength = 1,
                NumPercent = 30,
                LetterPercent = 60,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Проверяет, возвращает ли метод IsValid значение false, когда сумма процентов не равна 100.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenPercentageSumIsNotHundred()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 5,
                MinLength = 5,
                MaxLength = 10,
                NumPercent = 0,
                LetterPercent = 60,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char> { '@', '#', '$', '%' }),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Проверяет, возвращает ли метод IsValid значение false, когда все списки пусты.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenAllListCountsAreZero()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 10,
                MinLength = 3,
                MaxLength = 10,
                NumPercent = 20,
                LetterPercent = 30,
                SymbolPercent = 50,
                Symbols = new CharList(new List<char>()),
                Letters = new CharList(new List<char>()),
                Numbers = new CharList(new List<char>()),
            };

            // Act
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Проверяет, возвращает ли метод IsValid значение false, когда счетчики списка равны нулю, а проценты не равны нулю.
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalse_WhenListCountsIsZeroWhileAssignedPercentIsNot()
        {
            // Arrange
            var mask = new Mask
            {
                Count = 10,
                MinLength = 3,
                MaxLength = 10,
                NumPercent = 50,
                LetterPercent = 40,
                SymbolPercent = 10,
                Symbols = new CharList(new List<char>()),
                Letters = new CharList(new List<char> { 'a', 'b', 'c', 'd' }),
                Numbers = new CharList(new List<char> { '1', '2', '3', '4' }),
            };

            // Act
            bool isValid = _validator.IsValid(mask);

            // Assert
            Assert.False(isValid);
        }

    }
}
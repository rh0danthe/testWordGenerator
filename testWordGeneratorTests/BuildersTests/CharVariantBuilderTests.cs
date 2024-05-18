using AutoFixture.Xunit2;
using Moq;
using testWordGenerator.Builders;
using testWordGenerator.Models;
using testWordGenerator.Utils;
using Xunit;

namespace testWordGeneratorTests.BuildersTests
{
    /// <summary>
    /// Тесты для класса CharVariantBuilder.
    /// </summary>
    public class CharVariantBuilderTests : IClassFixture<CharVariantBuilder>
    {

        /// <summary>
        /// Проверяет, что метод Build возвращает объект типа CharList.
        /// </summary>
        [Fact]
        public void Build_ReturnsCharList()
        {
            // Act
            var localBuilder = new CharVariantBuilder();
            var result1 = localBuilder.Build();
            var result2 = localBuilder.Build();

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<CharList>(result1);
            Assert.Same(result1, result2);
        }
        
        /// <summary>
        /// Проверяет, что метод With возвращает объект типа CharVariantBuilder.
        /// </summary>
        [Fact]
        public void With_ReturnsCharVariantBuilder()
        {
            //Arrange
            var localBuilder = new CharVariantBuilder();
            var chars = new CharList();
            chars.AddRange(new char[] { 'a', 'b', 'c' });
            // Act
            var result1 = localBuilder.With(chars);
            var result2 = localBuilder.Build();

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<CharVariantBuilder>(result1);
            Assert.Equal(chars.Items, result2.Items);
        }
        
        /// <summary>
        /// Проверяет, что метод With возвращает объект типа CharVariantBuilder с заданными символами.
        /// </summary>
        /// <param name="chars">Символы для добавления.</param>
        [Theory]
        [InlineData(new char[]{'a', 'b', 'c'})]
        public void With_ReturnsCharVariantBuilder(params char[] chars)
        {
            //Arrange
            var localBuilder = new CharVariantBuilder();
            // Act
            var result1 = localBuilder.With(chars);
            var result2 = localBuilder.Build();

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<CharVariantBuilder>(result1);
            Assert.Equal(chars, result2.Items);
        }
        
        /// <summary>
        /// Проверяет, что метод WithRussian возвращает объект типа CharVariantBuilder с русскими символами.
        /// </summary>
        /// <param name="uppercase">Указывает, должны ли быть символы в верхнем регистре.</param>
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void WithRussian_ReturnsCharVariantBuilder(bool uppercase)
        {
            //Arrange
            var localBuilder = new CharVariantBuilder();
            // Act
            var result1 = localBuilder.WithRussian(uppercase);
            var result2 = localBuilder.Build();
            var testData = CharListFactory.GetRussianCharacters(uppercase);

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<CharVariantBuilder>(result1);
            Assert.Equal(result2.Items, result2.Items);
            Assert.Equal(testData, result2.Items);
        }
        
        /// <summary>
        /// Проверяет, что метод WithEnglish возвращает объект типа CharVariantBuilder с английскими символами.
        /// </summary>
        /// <param name="uppercase">Указывает, должны ли быть символы в верхнем регистре.</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WithEnglish_ReturnsCharVariantBuilder(bool uppercase)
        {
            //Arrange
            var localBuilder = new CharVariantBuilder();
            // Act
            var result1 = localBuilder.WithEnglish(uppercase);
            var result2 = localBuilder.Build();
            var testData = CharListFactory.GetEnglishCharacters(uppercase);

            // Assert
            Assert.NotNull(result1);
            Assert.IsType<CharVariantBuilder>(result1);
            Assert.IsType<CharVariantBuilder>(result1);
            Assert.Equal(result2.Items, result2.Items);
            Assert.Equal(testData, result2.Items);
        }
    }
}
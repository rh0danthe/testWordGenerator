using System.Linq;
using testWordGenerator.Models;
using testWordGenerator.Utils;

namespace testWordGenerator.Builders
{
    /// <summary>
    ///Builder для различных символов
    /// </summary>
    public class CharVariantBuilder
    {
        private CharList _chars = new CharList();
        
        /// <summary>
        /// Строит коллекцию символов.
        /// </summary>
        /// <returns>Построенная коллекция символов.</returns>
        public CharList Build()
        {
            return _chars;
        }

        /// <summary>
        /// Добавляет указанные символы в коллекцию.
        /// </summary>
        /// <param name="chars">Добавляемые символы.</param>
        /// <returns>Экземпляр CharVariantBuilder.</returns>
        public CharVariantBuilder With(params char[] chars)
        {
            _chars.AddRange(chars);
            return this;
        }
        
        /// <summary>
        /// Добавляет символы из указанного CharList в коллекцию.
        /// </summary>
        /// <param name="chars">CharList, содержащий добавляемые символы.</param>
        /// <returns>Экземпляр CharVariantBuilder.</returns>
        public CharVariantBuilder With(CharList chars)
        {
            _chars.AddRange(chars);
            return this;
        }

        /// <summary>
        /// Добавляет русские символы в коллекцию.
        /// </summary>
        /// <param name="uppercase">Указывает, добавлять ли прописные символы.</param>
        /// <returns>Экземпляр CharVariantBuilder.</returns>
        public CharVariantBuilder WithRussian(bool uppercase = false)
        {
            _chars.AddRange(CharListFactory.GetRussianCharacters(uppercase).ToArray());
            return this;
        }

        /// <summary>
        /// Добавляет английские символы в коллекцию.
        /// </summary>
        /// <param name="uppercase">Указывает, добавлять ли прописные символы.</param>
        /// <returns>Экземпляр CharVariantBuilder.</returns>
        public CharVariantBuilder WithEnglish(bool uppercase = false)
        {
            _chars.AddRange(CharListFactory.GetEnglishCharacters(uppercase).ToArray());
            return this;
        }
    }
}
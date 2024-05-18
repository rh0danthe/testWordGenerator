using System;
using System.Collections.Generic;
using System.Linq;
using testWordGenerator.Models;

namespace testWordGenerator.Services
{
    /// <summary>
    /// Сервис для генерации слов.
    /// </summary>
    public class WordService
    {
        private static WordService _instance;

        /// <summary>
        /// Получает экземпляр класса WordService.
        /// </summary>
        /// <returns>Экземпляр класса WordService.</returns>
        public static WordService GetInstance()
        {
            return _instance ??= new WordService();
        }
        
        private WordService() {}
        
        private readonly Random _rnd = new Random();

        /// <summary>
        /// Генерирует список слов на основе маски.
        /// </summary>
        /// <param name="mask">Маска для генерации слов.</param>
        /// <returns>Список сгенерированных слов.</returns>
        public List<Word> GenerateWords(Mask mask)
        {
            var collection = new List<Word>();
            for (int i = 0; i < mask.Count; i++)
            {
                var word = new Word
                {
                    Content = Generator(mask)
                };
                collection.Add(word);
            }

            return collection;
        }
        
        /// <summary>
        /// Генерирует слово на основе маски.
        /// </summary>
        /// <param name="mask">Маска для генерации слова.</param>
        /// <returns>Сгенерированное слово.</returns>
        private string Generator(Mask mask)
        {
            int length = _rnd.Next(mask.MinLength, mask.MaxLength + 1);
            int numCount = length * mask.NumPercent / 100;
            int letterCount = length * mask.LetterPercent / 100;
            int symbolCount = length - numCount - letterCount;

            List<char> wordChars = new List<char>();

            for (int j = 0; j < numCount; j++)
            {
                if (mask.Numbers.Items.Count == 0)
                    break;
                wordChars.Add(mask.Numbers.Items[_rnd.Next(mask.Numbers.Items.Count)]);
            }

            for (int j = 0; j < letterCount; j++)
            {
                if (mask.Letters.Items.Count == 0)
                    break;
                wordChars.Add(mask.Letters.Items[_rnd.Next(mask.Letters.Items.Count)]);
            }

            for (int j = 0; j < symbolCount; j++)
            {
                if (mask.Symbols.Items.Count == 0)
                    break;
                wordChars.Add(mask.Symbols.Items[_rnd.Next(mask.Symbols.Items.Count)]);
            }

            wordChars = wordChars.OrderBy(c => _rnd.Next()).ToList();

            return new string(wordChars.ToArray());
        }
    }
}

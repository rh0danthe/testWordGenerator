using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testWordGenerator.Models;
using testWordGenerator.Repository;

namespace testWordGenerator.Services
{
    internal class WordService
    {
        private static readonly WordRepository _repository = new WordRepository();
        private Random _rnd = new Random();

        public void GenerateWords(Mask mask)
        {
            for (int i = 0; i < mask.Count; i++)
            {
                var word = new Word();
                word.Content = Generator(mask);
                _repository.Add(word);
            }

        }

        public ObservableCollection<Word> GetAll()
        {
            return _repository.GetAll();
        }
        
        public string Generator(Mask mask)
        {
            int length = _rnd.Next(mask.MinLength, mask.MaxLength + 1);
            int numCount = length * mask.NumPercent / 100;
            int letterCount = length * mask.LetterPercent / 100;
            int symbolCount = length - numCount - letterCount;

            List<char> wordChars = new List<char>();

            for (int j = 0; j < numCount; j++)
            {
                wordChars.Add(mask.NumList.Items[_rnd.Next(mask.NumList.Items.Count)]);
            }

            for (int j = 0; j < letterCount; j++)
            {
                wordChars.Add(mask.CharList.Items[_rnd.Next(mask.CharList.Items.Count)]);
            }

            for (int j = 0; j < symbolCount; j++)
            {
                wordChars.Add(mask.SymbolList.Items[_rnd.Next(mask.SymbolList.Items.Count)]);
            }

            wordChars = wordChars.OrderBy(c => _rnd.Next()).ToList();

            return new string(wordChars.ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testWordGenerator.Models;

namespace testWordGenerator.Repository
{
    internal class WordRepository
    {
        private static ObservableCollection<Word> _Words = new ObservableCollection<Word>();

        public ObservableCollection<Word> GetAll()
        {
            return _Words;

        }


        public void Add(Word word)
        {
            _Words.Add(word);
        }

    }
}

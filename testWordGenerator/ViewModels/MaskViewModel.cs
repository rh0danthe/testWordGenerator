using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using testWordGenerator.Presenters;

namespace testWordGenerator.ViewModels
{
    /// <summary>
    /// Представляет модель представления маски.
    /// </summary>
    public class MaskViewModel : ViewModelBase
    {
        private int _minLength = 3;
        private int _maxLength = 15;
        private int _numberPercent = 30;
        private int _letterPercent = 30;
        private int _symbolPercent = 40;
        private int _count = 15;

        /// <summary>
        /// Коллекция языков.
        /// </summary>
        public ObservableCollection<ItemPresenter> Language { get; } = new ObservableCollection<ItemPresenter>
        {
            new ItemPresenter("Русский"),
            new ItemPresenter("Английский")
        };

        /// <summary>
        /// Коллекция регистров букв.
        /// </summary>
        public ObservableCollection<ItemPresenter> Case { get; } = new ObservableCollection<ItemPresenter>
        {
            new ItemPresenter("Большие буквы"),
            new ItemPresenter("Маленькие буквы")
        };

        /// <summary>
        /// Коллекция цифр.
        /// </summary>
        public ObservableCollection<ItemPresenter> Numbers { get; } =
            new ObservableCollection<ItemPresenter>("0123456789".Select(i => new ItemPresenter(i + "")));

        /// <summary>
        /// Коллекция символов.
        /// </summary>
        public ObservableCollection<ItemPresenter> Symbols { get; } =
            new ObservableCollection<ItemPresenter>("!@#$%^&*()".Select(i => new ItemPresenter(i + "")));

        /// <summary>
        /// Минимальная длина слова.
        /// </summary>
        public int MinLength
        {
            get => _minLength;
            set
            {
                _minLength = value;
                OnPropertyChanged("MinLength");
            }
        }

        /// <summary>
        /// Максимальная длина слова.
        /// </summary>
        public int MaxLength
        {
            get => _maxLength;
            set

            {
                _maxLength = value;
                OnPropertyChanged("MaxLength");
            }
        }

        /// <summary>
        /// Процент цифр в слове.
        /// </summary>
        public int NumberPercent
        {
            get => _numberPercent;
            set

            {
                _numberPercent = value;
                OnPropertyChanged("NumberPercent");
            }
        }

        /// <summary>
        /// Процент букв в слове.
        /// </summary>
        public int LetterPercent
        {
            get => _letterPercent;
            set

            {
                _letterPercent = value;
                OnPropertyChanged("LetterPercent");
            }
        }

        /// <summary>
        /// Процент символов в слове.
        /// </summary>
        public int SymbolPercent
        {
            get => _symbolPercent;
            set

            {
                _symbolPercent = value;
                OnPropertyChanged("SymbolPercent");
            }
        }

        /// <summary>
        /// Количество генерируемых слов.
        /// </summary>
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }
    }
}
using System.Collections.Generic;

namespace testWordGenerator.Models
{
    /// <summary>
    /// Представляет список символов.
    /// </summary>
    public class CharList
    {
        /// <summary>
        /// Коллекция элементов списка символов.
        /// </summary>
        public List<char> Items { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса CharList с указанными элементами.
        /// </summary>
        /// <param name="items">Элементы, которые будут добавлены в список символов.</param>
        public CharList(IEnumerable<char> items)
        {
            Items = new List<char>(items);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса CharList.
        /// </summary>
        public CharList()
        {
            Items = new List<char>();
        }

        /// <summary>
        /// Добавляет символ в список.
        /// </summary>
        /// <param name="ch">Символ для добавления.</param>
        public void Add(char ch)
        {
            Items.Add(ch);
        }

        /// <summary>
        /// Добавляет набор символов в список.
        /// </summary>
        /// <param name="chars">Символы для добавления.</param>
        public void AddRange(params char[] chars)
        {
            Items.AddRange(chars);
        }
        
        /// <summary>
        /// Добавляет символы из другого CharList в текущий список.
        /// </summary>
        /// <param name="chars">Список символов для добавления.</param>
        public void AddRange(CharList chars)
        {
            Items.AddRange(chars.Items);
        }
    }
}

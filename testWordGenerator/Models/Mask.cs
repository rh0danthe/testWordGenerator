using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWordGenerator.Models
{
    /// <summary>
    /// Представляет маску для генерации слова.
    /// </summary>
    public class Mask
    {
        /// <summary>
        /// Минимальная длина слова.
        /// </summary>
        public int MinLength { get; set; }
        
        /// <summary>
        /// Максимальная длина слова.
        /// </summary>
        public int MaxLength { get; set; }
        
        /// <summary>
        /// Процентное соотношение цифр в слове.
        /// </summary>
        public int NumPercent { get; set; }
        
        /// <summary>
        /// Процентное соотношение букв в слове.
        /// </summary>
        public int LetterPercent { get; set; }
        
        /// <summary>
        /// Процентное соотношение символов в слове.
        /// </summary>
        public int SymbolPercent { get; set; }
        
        /// <summary>
        /// Количество слов, которые нужно сгенерировать по данной маске.
        /// </summary>
        public int Count { get; set; }
        
        /// <summary>
        /// Список символов, используемых в словах.
        /// </summary>
        public CharList Letters { get; set; }
        
        /// <summary>
        /// Список цифр, используемых в словах.
        /// </summary>
        public CharList Numbers { get; set; }
        
        /// <summary>
        /// Список символов, используемых в словах.
        /// </summary>
        public CharList Symbols { get; set; }
    }
}

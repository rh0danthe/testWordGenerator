using testWordGenerator.Models;

namespace testWordGenerator.Strategies
{
    /// <summary>
    /// Абстрактный класс стратегии сохранения слова.
    /// </summary>
    public abstract class WordSaveStrategy
    {
        /// <summary>
        /// Сохраняет слово в соответствии с заданной стратегией.
        /// </summary>
        /// <param name="mask">Маска слова.</param>
        public abstract void Save(Mask mask);
    }
}
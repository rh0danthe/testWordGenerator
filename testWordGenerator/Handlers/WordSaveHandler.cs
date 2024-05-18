using testWordGenerator.Models;
using testWordGenerator.Strategies;

namespace testWordGenerator.Handlers
{
    /// <summary>
    /// Обработчик сохранения слов в документе.
    /// </summary>
    public class WordSaveHandler
    {
        private readonly WordSaveStrategy _strategy;

        /// <summary>
        /// Инициализирует новый экземпляр класса WordSaveHandler с указанной стратегией сохранения.
        /// </summary>
        /// <param name="strategy">Стратегия сохранения слова.</param>
        public WordSaveHandler(WordSaveStrategy strategy)
        {
            _strategy = strategy;
        }

        /// <summary>
        /// Открывает диалог сохранения слов в документе, используя текущую стратегию.
        /// </summary>
        /// <param name="mask">Маска для генерации слов.</param>
        public void OpenDialog(Mask mask)
        {
            _strategy.Save(mask);
        }
    }
}
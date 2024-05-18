using System.Windows;
using testWordGenerator.Models;

namespace testWordGenerator.Strategies
{
    /// <summary>
    /// Стратегия сохранения слова в случае ошибки.
    /// </summary>
    public class WordSaveErrorStrategy : WordSaveStrategy
    {
        /// <summary>
        /// Представляет поведение в случае ошибки.
        /// </summary>
        /// <param name="mask">Маска слова.</param>
        public override void Save(Mask mask)
        {
            MessageBox.Show("Введенные данные некорректны");
        }
    }
}
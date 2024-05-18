using System.IO;
using System.Windows;
using Microsoft.Win32;
using testWordGenerator.Models;
using testWordGenerator.Services;

namespace testWordGenerator.Strategies
{
    /// <summary>
    /// Стратегия сохранения слова в случае успешной генерации.
    /// </summary>
    public class WordSaveSuccessStrategy : WordSaveStrategy
    {
        /// <summary>
        /// Сохраняет сгенерированные слова в текстовый файл.
        /// </summary>
        /// <param name="mask">Маска слова.</param>
        public override void Save(Mask mask)
        {
            var result = WordService.GetInstance().GenerateWords(mask);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var item in result)
                    {
                        writer.WriteLine(item.Content);
                    }
                }
                
                MessageBox.Show("Файл успешно сохранен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
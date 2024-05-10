using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using testWordGenerator.Models;
using testWordGenerator.Services;
using testWordGenerator.Utils;

namespace testWordGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WordService _service = new WordService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            var mask = new Mask();
            mask.MinLength = Convert.ToInt32(minLengthTextBox.Text);
            mask.MaxLength = Convert.ToInt32(maxLengthTextBox.Text);
            mask.SymbolPercent = Convert.ToInt32(SymbolPercent.Text);
            mask.NumPercent = Convert.ToInt32(NumPercent.Text);
            mask.LetterPercent = Convert.ToInt32(LetterPercent.Text);
            mask.Count = Convert.ToInt32(wordCountTextBox.Text);
            mask.SymbolList = new SymbolList();
            mask.NumList = new NumList();
            mask.CharList = new CharList();
            foreach (ListBoxItem item in symbolComboBox.SelectedItems)
            {
                mask.SymbolList.Items.Add(Convert.ToChar(item.Content));
            }
            foreach (ListBoxItem item in numberComboBox.SelectedItems)
            {
                mask.NumList.Items.Add(Convert.ToChar(item.Content));
            }
            
            List<string> selectedItems = new List<string>();
            foreach (ListBoxItem item in languageComboBox.SelectedItems)
            {
                selectedItems.Add(item.Content.ToString());
            }

            // Заполняем список в соответствии с выбранными элементами
            foreach (string item in selectedItems)
            {
                if (item == "Русский")
                {
                    if (selectedItems.Contains("Маленькие буквы"))
                    {
                        SymbolGenerator.GetRussianLowercaseCharacters(mask.CharList.Items);
                    }
                    if (selectedItems.Contains("Большие буквы"))
                    {
                        SymbolGenerator.GetRussianUppercaseCharacters(mask.CharList.Items);
                    }
                }
                else if (item == "Английский")
                {
                    if (selectedItems.Contains("Маленькие буквы"))
                    {
                        SymbolGenerator.GetEnglishLowercaseCharacters(mask.CharList.Items);
                    }
                    if (selectedItems.Contains("Большие буквы"))
                    {
                        SymbolGenerator.GetEnglishUppercaseCharacters(mask.CharList.Items);
                    }
                }
            }
            _service.GenerateWords(mask);
            save_button.Visibility = Visibility.Visible;
            msg_label.Visibility = Visibility.Visible;
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            var result = _service.GetAll();
            // Открываем диалоговое окно сохранения файла
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*"; // Фильтр для выбора типа файла
            if (saveFileDialog.ShowDialog() == true)
            {
                // Получаем путь к выбранному файлу
                string filePath = saveFileDialog.FileName;

                // Создаем или перезаписываем файл
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Перебираем элементы коллекции и записываем их в файл
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

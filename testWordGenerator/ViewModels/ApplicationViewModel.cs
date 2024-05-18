using System.IO;
using System.Windows;
using Microsoft.Win32;
using testWordGenerator.Commands;
using testWordGenerator.Services;
using testWordGenerator.ViewModels.Adapters;

namespace testWordGenerator.ViewModels
{
    /// <summary>
    /// Представляет модель представления приложения.
    /// </summary>
    public class ApplicationViewModel : ViewModelBase
    {
        private MaskViewModel _mask = new MaskViewModel();

        /// <summary>
        /// Модель представления маски.
        /// </summary>
        public MaskViewModel Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                OnPropertyChanged("Mask");
            }
        }

        /// <summary>
        /// Команда для генерации слова.
        /// </summary>
        public GenerateCommand GenerateCommand { get; private set; } = new GenerateCommand();
    }
}
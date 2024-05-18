using System.ComponentModel;
using testWordGenerator.Builders;

namespace testWordGenerator.ViewModels
{
    /// <summary>
    /// Базовый класс для моделей представления, реализующий интерфейс INotifyPropertyChanged.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, возникающее при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged для указанного свойства.
        /// </summary>
        /// <param name="propertyName">Имя свойства, для которого произошло изменение.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
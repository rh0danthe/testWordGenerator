using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace testWordGenerator.Presenters.Abstract
{
    /// <summary>
    /// Базовый абстрактный класс презентера, реализующий интерфейс INotifyPropertyChanged.
    /// </summary>
    public abstract class Presenter : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, возникающее при изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged для указанного свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using testWordGenerator.Presenters.Abstract;

namespace testWordGenerator.Presenters
{
    /// <summary>
    /// Представляет элемент презентации.
    /// </summary>
    public class ItemPresenter : Presenter
    {
        private readonly string _value;

        /// <summary>
        /// Инициализирует новый экземпляр класса ItemPresenter с указанным значением.
        /// </summary>
        /// <param name="value">Значение элемента.</param>
        public ItemPresenter(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Возвращает строковое представление элемента.
        /// </summary>
        /// <returns>Строковое представление элемента.</returns>
        public override string ToString()
        {
            return _value;
        }
        
        private bool _isSelected;
        
        /// <summary>
        /// Определяет, выбран ли элемент.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }
    }
}
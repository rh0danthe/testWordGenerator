using System;
using System.Windows.Input;

namespace testWordGenerator.Commands
{
    /// <summary>
    /// Базовая абстрактная реализация интерфейса ICommand.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Условие выполнения команды.
        /// </summary>
        public abstract bool ExecuteCondition { get; set; }
        
        /// <summary>
        /// Событие, возникающее при изменении возможности выполнения команды.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Определяет, может ли команда быть выполнена в текущем состоянии.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        /// <returns>True, если команда может быть выполнена, в противном случае - false.</returns>
        public bool CanExecute(object parameter) => ExecuteCondition;

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public abstract void Execute(object parameter);
    }
}
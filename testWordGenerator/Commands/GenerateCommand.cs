using testWordGenerator.Handlers;
using testWordGenerator.Strategies;
using testWordGenerator.Validators;
using testWordGenerator.ViewModels;
using testWordGenerator.ViewModels.Adapters;

namespace testWordGenerator.Commands
{
    /// <summary>
    /// Команда для генерации слов.
    /// </summary>
    public class GenerateCommand : BaseCommand //шаблонный метод
    {
        /// <summary>
        /// Условие выполнения команды. Всегда установлено в true.
        /// </summary>
        public override bool ExecuteCondition { get; set; } = true;
        
        /// <summary>
        /// Выполняет генерацию слова в документе.
        /// </summary>
        /// <param name="parameter">Параметр команды.</param>
        public override void Execute(object parameter) 
        {
            var isValidMask = new MaskViewModelAdapter(parameter as MaskViewModel).TryGetMask(out var mask);
            var isValidParams = new MaskValidator().IsValid(mask);
            WordSaveStrategy strategy;
            if (!isValidMask || !isValidParams)
            {
                strategy = new WordSaveErrorStrategy();
            }
            else
            {
                strategy = new WordSaveSuccessStrategy();
            }

            var wordSaveHandler = new WordSaveHandler(strategy);
            wordSaveHandler.OpenDialog(mask);
        }
    }
}
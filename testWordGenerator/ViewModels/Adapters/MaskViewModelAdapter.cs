using System.Linq;
using testWordGenerator.Builders;
using testWordGenerator.Models;

namespace testWordGenerator.ViewModels.Adapters
{
    /// <summary>
    /// Адаптер для преобразования объекта представления маски в объект маски.
    /// </summary>
    public class MaskViewModelAdapter
    {
        private readonly MaskViewModel _viewmodel;

        /// <summary>
        /// Инициализирует новый экземпляр класса MaskViewModelAdapter с указанным объектом представления маски.
        /// </summary>
        /// <param name="viewmodel">Объект представления маски.</param>
        public MaskViewModelAdapter(MaskViewModel viewmodel)
        {
            _viewmodel = viewmodel;
        }

        /// <summary>
        /// Пытается получить объект маски из объекта представления маски.
        /// </summary>
        /// <param name="mask">Возвращаемый объект маски.</param>
        /// <returns>True, если удалось получить объект маски, иначе - false.</returns>
        public bool TryGetMask(out Mask mask)
        {
            try
            {
                var numbers = new CharList(_viewmodel.Numbers.Where(item => item.IsSelected)
                    .Select(item => item.ToString()[0]));
                var symbols = new CharList(_viewmodel.Symbols.Where(item => item.IsSelected)
                    .Select(item => item.ToString()[0]));

                var lettersBuilder = new CharVariantBuilder();

                var language = _viewmodel.Language.ToDictionary(k => k.ToString(), i => i.IsSelected);
                var letterCase = _viewmodel.Case.ToDictionary(k => k.ToString(), i => i.IsSelected);

                if (language.TryGetValue("Русский", out var russian) && russian)
                {
                    if (letterCase.TryGetValue("Большие буквы", out var upper) && upper)
                    {
                        lettersBuilder = lettersBuilder.WithRussian(true);
                    }

                    if (letterCase.TryGetValue("Маленькие буквы", out var lower) && lower)
                    {
                        lettersBuilder = lettersBuilder.WithRussian();
                    }
                }

                if (language.TryGetValue("Английский", out var english) && english)
                {
                    if (letterCase.TryGetValue("Большие буквы", out var upper) && upper)
                    {
                        lettersBuilder = lettersBuilder.WithEnglish(true);
                    }

                    if (letterCase.TryGetValue("Маленькие буквы", out var lower) && lower)
                    {
                        lettersBuilder = lettersBuilder.WithEnglish();
                    }
                }

                mask = new Mask
                {
                    Count = _viewmodel.Count,
                    LetterPercent = _viewmodel.LetterPercent,
                    MinLength = _viewmodel.MinLength,
                    MaxLength = _viewmodel.MaxLength,
                    NumPercent = _viewmodel.NumberPercent,
                    SymbolPercent = _viewmodel.SymbolPercent,
                    Letters = lettersBuilder.Build(),
                    Numbers = numbers,
                    Symbols = symbols
                };
                return true;
            }
            catch
            {
                mask = null;
                return false;
            }
        }
    }
}
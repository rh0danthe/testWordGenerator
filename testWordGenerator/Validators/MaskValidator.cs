using testWordGenerator.Models;

namespace testWordGenerator.Validators
{
    /// <summary>
    /// Проверяет корректность маски для генерации слова.
    /// </summary>
    public class MaskValidator
    {
        /// <summary>
        /// Проверяет, является ли маска корректной.
        /// </summary>
        /// <param name="mask">Маска для проверки.</param>
        /// <returns>True, если маска корректна, иначе - false.</returns>
        public bool IsValid(Mask mask)
        {
            if (mask.Count <= 0 || mask.MaxLength <= 0 || mask.MinLength <= 0 || mask.LetterPercent < 0 || mask.NumPercent < 0 || mask.SymbolPercent < 0) return false;
            if (mask.LetterPercent == 0 & mask.NumPercent == 0 & mask.SymbolPercent == 0) return false;
            if (mask.MaxLength < mask.MinLength) return false;
            if (mask.LetterPercent + mask.NumPercent + mask.SymbolPercent != 100) return false;
            if (mask.Letters.Items.Count + mask.Numbers.Items.Count + mask.Symbols.Items.Count == 0) return false;
            if (mask.Letters.Items.Count == 0 & mask.LetterPercent != 0) return false;
            if (mask.Numbers.Items.Count == 0 & mask.NumPercent != 0) return false;
            if (mask.Symbols.Items.Count == 0 & mask.SymbolPercent != 0) return false;
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWordGenerator.Models
{
    internal class Mask
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int NumPercent { get; set; }
        public int LetterPercent { get; set; }
        public int SymbolPercent { get; set; }
        public int Count { get; set; }
        public CharList CharList { get; set; }
        public NumList NumList { get; set; }
        public SymbolList SymbolList { get; set; }
    }
}

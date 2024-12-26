using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Serializable]
    public class FlashCardData : IComparable<FlashCardData>
    {
        public string Word { get; set; }
        public string Definition { get; set; }

        public FlashCardData() { }
        public FlashCardData(string word, string defintion)
        {
            Word = word;
            Definition = defintion;
        }

        public int CompareTo(FlashCardData? other)
        {
            return Comparer<string>.Default.Compare(other.Definition, this.Definition);
        }
    }
}

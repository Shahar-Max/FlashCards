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
        public string Defintion { get; set; }

        public FlashCardData() { }
        public FlashCardData(string word, string defintion)
        {
            Word = word;
            Defintion = defintion;
        }

        public int CompareTo(FlashCardData? other)
        {
            return Comparer<string>.Default.Compare(other.Defintion, this.Defintion);
        }
    }
}

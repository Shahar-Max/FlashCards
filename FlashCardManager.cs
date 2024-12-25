using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class FlashCardManager
    {
        private static readonly string SAVE_PATH = "flashcards.json";

        private List<FlashCardData> flashCards;
        private Random rand;

        public static FlashCardManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FlashCardManager();
                return _instance;
            }
        }
        private static FlashCardManager _instance;

        private FlashCardManager()
        {
            flashCards = new List<FlashCardData>();
            rand = new Random();
        }

        public FlashCardData? GetRandomFlashCard()
        {
            return this.flashCards == null ? null : flashCards[rand.Next(flashCards.Count)];
        }
        public void AddFlashCard(FlashCardData flashCard)
        {
            this.flashCards.Add(flashCard);
        }

        // Removes the first occurence of the word
        public void RemoveFlashCard(string word)
        {
            List<FlashCardData> tempList = new List<FlashCardData>(this.flashCards);
            foreach (FlashCardData flashCard in tempList)
            {
                if (flashCard.Word.Equals(word, StringComparison.InvariantCultureIgnoreCase))
                    this.flashCards.Remove(flashCard);
            }
        }

        public bool LoadFromFile()
        {
            return JsonUtils.Instance.GetFromFile<List<FlashCardData>>(SAVE_PATH, out flashCards);
        }

        public bool SaveToFile()
        {
            return JsonUtils.Instance.SaveToFile(this.flashCards, SAVE_PATH);
        }
    }
}

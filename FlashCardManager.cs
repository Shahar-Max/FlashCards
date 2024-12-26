using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class FlashCardManager
    {
        private static readonly string SAVE_PATH = "flashcards.json";

        private List<FlashCardData> flashCards;
        private List<FlashCardData> usedCards;
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
            this.flashCards = new List<FlashCardData>();
            this.usedCards = new List<FlashCardData>();
            this.rand = new Random();
        }

        public FlashCardData? GetRandomFlashCard()
        {
            if (this.flashCards == null || this.flashCards.Count == 0)
                return null;

            FlashCardData card = flashCards[rand.Next(flashCards.Count)];

            return card;
        }

        public void UseCard(FlashCardData card)
        {
            this.flashCards.Remove(card);
            this.usedCards.Add(card);
        }

        public void ObliterateCard(FlashCardData card)
        {
            if (flashCards.Contains(card))
                this.flashCards.Remove(card);
            else
                this.usedCards.Remove(card);
        }

        public void UnuseAllCards()
        {
            this.flashCards.AddRange(this.usedCards);
            this.usedCards.Clear();
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
            List<FlashCardData> newCards = new List<FlashCardData>();
            JsonUtils.Instance.GetFromFile<List<FlashCardData>>(SAVE_PATH, out newCards);

            if (newCards != null)
                this.flashCards = newCards;

            return newCards != null;
        }

        public void SaveToFile()
        {
            if (!File.Exists(SAVE_PATH))
                File.Create(SAVE_PATH);

            this.UnuseAllCards();
            JsonUtils.Instance.SaveToFile(this.flashCards, SAVE_PATH);
        }
    }
}

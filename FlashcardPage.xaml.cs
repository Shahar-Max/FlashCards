using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for FlashcardPage.xaml
    /// </summary>
    public partial class FlashcardPage : Page
    {
        private FlashCard currentFlashCard;

        public FlashcardPage()
        {
            InitializeComponent();
            InitInputs();
            DataContext = this;

            bool init = FlashCardManager.Instance.LoadFromFile();
            if (!init)
                FlashCardManager.Instance.SaveToFile();

            ShowRandomFlashCard();
        }

        private void InitInputs()
        {
            returnToPoolBtn.Click += (_, __) =>
            {
                HideCard();
                ShowRandomFlashCard();
            };

            useCurrentCardBtn.Click += (_, __) =>
            {
                FlashCardManager.Instance.UseCard(currentFlashCard.CardData);
                HideCard();
                ShowRandomFlashCard();
            };

            removeCardBtn.Click += (_, __) =>
            {
                FlashCardManager.Instance.ObliterateCard(currentFlashCard.CardData);
                HideCard();
                ShowRandomFlashCard();
            };

            flipBtn.Click += (_, __) =>
            {
                if (currentFlashCard != null)
                    currentFlashCard.Toggle();
            };
        }

        private void ShowRandomFlashCard()
        {
            FlashCardData data = FlashCardManager.Instance.GetRandomFlashCard();
            if (data == null)
                return;

            FlashCard card = new FlashCard(data);
            this.currentFlashCard = card;

            Grid.SetRow(card, 0);
            Grid.SetColumn(card, 1);

            Grid.Children.Add(card);
        }

        private void HideCard()
        {
            Grid.Children.Remove(currentFlashCard);
        }
    }
}

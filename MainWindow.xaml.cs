using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlashCardData currentFlashCard;
        public MainWindow()
        {
            InitializeComponent();

            bool init = FlashCardManager.Instance.LoadFromFile();
            if (!init)
                FlashCardManager.Instance.SaveToFile();

            ShowRandomFlashCard();
            crtnModeBtn.Click += OpenCreationWindow;
            useCurrentCardBtn.Click += (_, __) =>
            {
                FlashCardManager.Instance.UseCard(currentFlashCard);
                HideCard();
                ShowRandomFlashCard();
            };

            returnToPoolBtn.Click += (_, __) => ShowRandomFlashCard();
            KILLKILLKILL.Click += (_, __) =>
            {
                FlashCardManager.Instance.ObliterateCard(currentFlashCard);
                HideCard();
                ShowRandomFlashCard();
            };
        }

        private void HideCard()
        {
            cardContainer.Child = null;
        }

        private void OpenCreationWindow(object sender, RoutedEventArgs e)
        {
            var window = new CreationWindow();
            window.Show();
            this.Hide();
        }

        private void ShowRandomFlashCard()
        {
            FlashCardData data = FlashCardManager.Instance.GetRandomFlashCard();
            if (data == null)
                return;

            this.currentFlashCard = data;
            FlashCard card = new FlashCard(data);
            cardContainer.Child = card;
        }

        /*
        private void Chapter2()
        {
            dict["אין לאל ידו"] = "אין באפשרותו";
            dict["משוא פנים"] = "יחס שאינו צודק, אפליה";
        }
        private void Chapter1()
        {
            dict["אורים ותמים"] = "מקור מוסמך שלא נהוג להרהר אחריו";
            dict["אונגרד"] = "חלוץ";
            dict["אזלת יד"] = "חוסר יכולת לעשות דבר מסוים";
            dict["אינהרנט"] = "חלק בלתי נפרד";
            dict["אינטרוספקציה"] = "הסתכלות פנימית";
            dict["איולת"] = "שטות, מעשי איולת";
            dict["אינו עשוי מקשה אחת"] = "מורכב מפלגים שונים";
            dict["איפה ואיפה"] = "יחס שאינו צודק, אפליה";
            dict["אמביולנטי"] = "דו ערכיות - שנאה ואהבה כלפי אותו אדם בוז";
            dict["אנכרוניסטי"] = "לא שייך לזמנו, מיושן";
            dict["אנטגוניזם"] = "התנגדות חריפה";
            dict["אפריורי"] = "קבוע מראש, אופן אפריורי";
        }
        */
    }
}
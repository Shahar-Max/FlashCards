using System.IO;
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
        bool isShowingDesc = false;
        Random rnd;
        Dictionary<string, string> dict = new Dictionary<string, string>();
        string curValue = "";
        string curKey = "";
        public MainWindow()
        {
            rnd = new Random();
            InitializeComponent();
            Chapter1();
            RandomiseWord();
        }

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

        private void RandomiseWord()
        {
            int index = rnd.Next(dict.Count);
            int counter = 0;
            foreach (string key in dict.Keys)
            {
                if (counter == index)
                {
                    curKey = key;
                    curValue = dict[key];
                    mainButton.Content = curKey;
                    isShowingDesc = false;
                    return;
                }
                counter++;
            }
            //dict.Keys[]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isShowingDesc)
            {
                mainButton.Content = curKey;
            }
            else
            {
                mainButton.Content = curValue;
            }
            
            isShowingDesc = !isShowingDesc;
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            dict.Remove(curKey);
            RandomiseWord();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            RandomiseWord();
        }
    }
}
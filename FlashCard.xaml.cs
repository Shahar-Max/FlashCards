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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for FlashCard.xaml
    /// </summary>
    public partial class FlashCard : UserControl
    {
        public FlashCardData CardData { get; private set; }

        public FlashCard(FlashCardData data)
        {
            InitializeComponent();
            this.CardData = data;
            fcPrompt.Content = CardData.Word;

            //fcPrompt.Click += (_, __) => Toggle();
        }

        public void Toggle()
        {
            fcPrompt.Content = fcPrompt.Content.Equals(CardData.Definition) ? CardData.Word : CardData.Definition;
        }
    }
}

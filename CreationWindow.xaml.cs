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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for CreationWindow.xaml
    /// </summary>
    public partial class CreationWindow : Window
    {
        public CreationWindow()
        {
            InitializeComponent();
            addBtn.Click += Submit;
            returnBtn.Click += ReturnToView;
        }

        private void ReturnToView(object sender, RoutedEventArgs e)
        {
            FlashCardManager.Instance.SaveToFile();
            new MainWindow().Show();
            this.Hide();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(fcWord.Text) && !string.IsNullOrEmpty(fcDef.Text))
                FlashCardManager.Instance.AddFlashCard(new FlashCardData(fcWord.Text, fcDef.Text)); 

            ResetInputs();
        }

        private void ResetInputs()
        {
            fcWord.Text = "";
            fcDef.Text = "";
        }
    }
}

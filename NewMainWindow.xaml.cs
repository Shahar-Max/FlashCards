using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NewMainWindow.xaml
    /// </summary>
    public partial class NewMainWindow : FluentWindow
    {
        public ObservableCollection<NavigationViewItem> MenuItems { get; set; }

        public NewMainWindow()
        {
            DataContext = this;
            InitializeComponent();

            this.Show();
            Navigate(typeof(FlashcardPage));

        }

        public Snackbar GetWarningSnackbar(string title, string content)
        {
            return new Snackbar(SnackbarPresenter)
            {
                Title = title,
                Appearance = ControlAppearance.Success,
                Content = content,
                Icon = new SymbolIcon { Symbol = SymbolRegular.Checkmark12 },
            };
        }

        public void ShowSnack()
        {
            SnackbarPresenter.AddToQue(GetWarningSnackbar("Json Success", "The system successfully loadded\nthe needed files."));
        }

        public INavigationView GetNavigation()
        {
            return RootNavigation;
        }

        public bool Navigate(Type pageType)
        {
            return RootNavigation.Navigate(pageType);
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            RootNavigation.SetServiceProvider(serviceProvider);
        }

        public void SetPageService(IPageService pageService)
        {
            RootNavigation.SetPageService(pageService);
        }

        public void ShowWindow()
        {
            Show();
        }

        public void CloseWindow()
        {
            Close();
        }
    }
}

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
using Bookstore.Infrastructure.Data.Model;
using Bookstore.Presentation.ViewModel;

namespace Databases_assignment_02_Bookstore_administration_version02;
//namespace Bookstore.Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Test
        //using var db = new BookStoreContext();
        //var stockBalance = db.StockBalances.ToList();

        DataContext = new MainWindowViewModel();
    }
}
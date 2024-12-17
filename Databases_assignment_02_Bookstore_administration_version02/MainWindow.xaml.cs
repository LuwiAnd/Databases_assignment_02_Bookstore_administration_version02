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
using Bookstore.Domain;
using Bookstore.Infrastructure.Data.Model;
using Bookstore.Presentation.ViewModel;

namespace Databases_assignment_02_Bookstore_administration_version02;
//namespace Bookstore.Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private StockBalance?  _selectedStockBalance;

    public StockBalance? SelectedStockBalance
    {
        get { return _selectedStockBalance; }
        set { _selectedStockBalance = value; }
    }

    public MainWindow()
    {
        InitializeComponent();

        // Test
        //using var db = new BookStoreContext();
        //var stockBalance = db.StockBalances.ToList();

        DataContext = new MainWindowViewModel();
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var x = (DataGrid)sender;
        var selectedItem = x.SelectedItem;
        SelectedStockBalance = (StockBalance)selectedItem;

        
    }

    //private void RemoveButton_Click(object sender, RoutedEventArgs e)
    //{

    //}

    private void RemoveButton_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedStockBalance == null)
        {
            MessageBox.Show("Please select a book to remove.");
            return;
        }

        // Ta bort från databasen
        using (var db = new BookStoreContext())
        {
            // Leta upp posten i databasen baserat på dess nyckel
            var stockBalanceToRemove = db.StockBalances
                .FirstOrDefault(sb => sb.Isbn13 == SelectedStockBalance.Isbn13 &&
                                      sb.StoreId == SelectedStockBalance.StoreId);

            if (stockBalanceToRemove != null)
            {
                db.StockBalances.Remove(stockBalanceToRemove);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Selected stock balance could not be found in the database.");
                return;
            }
        }

        // Uppdatera DataGrid
        var viewModel = (MainWindowViewModel)DataContext;
        viewModel.LoadStockBalances(); // Anropa en metod i ViewModel för att ladda om data

        // Nollställ SelectedStockBalance
        SelectedStockBalance = null;

        MessageBox.Show("Stock balance removed successfully.");
    }


    private void AddButton_Click(object sender, RoutedEventArgs e)
    {

    }
}
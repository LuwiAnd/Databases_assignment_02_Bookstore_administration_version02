using Bookstore.Domain;
using Bookstore.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Bookstore.Presentation
{
    /// <summary>
    /// Interaction logic for AddStockBalanceDialog.xaml
    /// </summary>
    public partial class AddStockBalanceDialog : Window, INotifyPropertyChanged
    {
        // Jag tror inte att jag använder den här variabeln.
        private readonly BookStoreContext _db;

        private string? _selectedAuthor;
        private string? _selectedBookTitle;
        private string? _selectedIsbn;
        private int? _count;

        private int selectedStoreId;
        
        
        




        //Jag har blandat Code-behind med MVVM, så om jag vill använda RaisePropertyChanged()-funktionen, så 
        //måste jag skapa ett till program i ViewModel-mappen som ärver av ViewModelBase.cs. Därför har jag 
        //kopierat den funktionen från det programmet hit, vilket är lite fult, men det bör fungera.
        public event PropertyChangedEventHandler? PropertyChanged;
        //public void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public string SelectedBookTitle
        {
            get => _selectedBookTitle;
            set
            {
                _selectedBookTitle = value;
                RaisePropertyChanged();
                UpdateAuthorList();
            }
        }


        public string SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _selectedAuthor = value;
                RaisePropertyChanged();
                UpdateIsbnList();
            }
        }

        


        public string SelectedIsbn
        {
            get => _selectedIsbn;
            set
            {
                _selectedIsbn = value;
                RaisePropertyChanged();
            }
        }




        private ObservableCollection<string> _bookTitles;
        public ObservableCollection<string> BookTitles
        {
            get => _bookTitles;
            set
            {
                _bookTitles = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _authors;
        public ObservableCollection<string> Authors
        {
            get => _authors;
            set
            {
                _authors = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<string> _isbnList;
        public ObservableCollection<string> IsbnList
        {
            get => _isbnList;
            set
            {
                _isbnList = value;
                RaisePropertyChanged();
            }
        }




        public int? Count
        {
            get => _count;
            set
            {
                _count = value;
                RaisePropertyChanged();
            }
        }

        // Jag ska nog göra en till konstruktor som tar emot ett ISBN-nummer från den bok man eventuellt markerat.
        public AddStockBalanceDialog()
        {
            selectedStoreId = 1; // Detta ska jag ändra sen!! ??!!???

            InitializeComponent();

            using var db = new BookStoreContext();

            var bookTitles = db.Books
                .Select(b => b.Title)
                .Distinct()
                .ToList();


            //_bookTitles = new ObservableCollection<string>(bookTitles);
            BookTitles = new ObservableCollection<string>(bookTitles);
            //_selectedBookTitle = _bookTitles.FirstOrDefault();
            SelectedBookTitle = BookTitles.FirstOrDefault();



            UpdateAuthorList();
            UpdateIsbnList();

            DataContext = this;
            //Istället för allt jag gör i denna konstruktor, så borde jag nog skapa en ny klass som motsvarar en sammanslagning av books och authors!! ??!!???
        }


        public AddStockBalanceDialog(StockBalance? initialStockBalance)
        {
            InitializeComponent();

            using var db = new BookStoreContext();

            _selectedIsbn = initialStockBalance.Isbn13;
            _selectedBookTitle = db.Books
                .FirstOrDefault(b => b.Isbn13 == _selectedIsbn)?
                .Title
            ;
            //.Where(b => b.Isbn13 == _selectedIsbn)
            //_selectedAuthor = db.Authors
            //.Include()


            //using var db = new BookStoreContext();
            var authorsAndBooks = db.Authors
                .Include(a => a.BookIsbns)
                .Where(a => a.BookIsbns.Any(b => b.Isbn13 == initialStockBalance.Isbn13))
                .Select(a => a.FirstName)
                .ToList()
                ;

            int x = 1;

            //this.AuthorList = authorsAndBooks
            //    .Include
            //    Obser authorsAndBooks =
            

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; // Denna variabel hittade ChatGPT på.
            Close();
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsbnComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an ISBN13.");
                return;
            }

            if (!int.TryParse(CountTextBox.Text, out int count) || count < 0)
            {
                MessageBox.Show("Please enter a valid positive number for the count.");
                return;
            }

            

            //string selectedIsbn = IsbnComboBox.SelectedItem.ToString();

            using var db = new BookStoreContext();

            var stockBalance = db.StockBalances
                .FirstOrDefault(sb => sb.StoreId == selectedStoreId && sb.Isbn13 == SelectedIsbn);

            if(stockBalance != null)
            {
                stockBalance.Count = count;
                MessageBox.Show("Stock balance updated successfully.");
            }
            else
            {
                var newStockBalance = new StockBalance
                {
                    StoreId = selectedStoreId,
                    Isbn13 = SelectedIsbn,
                    Count = count
                };
                db.StockBalances.Add(newStockBalance);
                MessageBox.Show("New book added to stock balance successfully.");
            }

            db.SaveChanges();

            DialogResult = true;
            Close();
        }


        private void UpdateAuthorList()
        {
            using var db = new BookStoreContext();

            var initialIsbnList = db.Books
                .Where(b => b.Title == SelectedBookTitle)
                .Select(b => b.Isbn13)
                .ToList();



            var authors = db.Authors
                .Include(a => a.BookIsbns)
                .Where(a => a.BookIsbns.Any(b => initialIsbnList.Contains(b.Isbn13)))
                .Select(a => a.FirstName + " " + a.LastName)
                .Distinct()
                .ToList()
                ;

            Authors = new ObservableCollection<string>(authors);
            SelectedAuthor = authors.FirstOrDefault();
        }


        private void UpdateIsbnList()
        {
            using var db = new BookStoreContext();

            var finalIsbnList = db.Books
                .Include(b => b.Authors)
                .Where(b =>
                    b.Title == SelectedBookTitle
                    &&
                    b.Authors.Any(a => (a.FirstName + " " + a.LastName) == SelectedAuthor)
                )
                .Select(b => b.Isbn13)
                .ToList()
            ;



            IsbnList = new ObservableCollection<string>(finalIsbnList);
            SelectedIsbn = IsbnList.FirstOrDefault();
        }

    }
}

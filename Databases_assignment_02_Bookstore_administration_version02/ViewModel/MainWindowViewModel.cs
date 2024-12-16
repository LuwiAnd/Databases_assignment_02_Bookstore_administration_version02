using Bookstore.Domain;
using Bookstore.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Presentation.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            LoadStockBalances();
        }

        //ObservableCollection<StockBalance> StockBalances { get; private set; } // Motsvarande denna kodrad fungerar för Fredrik, men den fungerar inte för mig (CompanyDemo_del3 14:00).
        //ObservableCollection<StockBalance> StockBalances { get; set; }
        //ObservableCollection<string> StockBalances { get; set; }
        //ObservableCollection<int> StockBalances { get; set; }
        public ObservableCollection<string> StoreNames { get; set; }

        private void LoadStockBalances()
        {
            using var db = new BookStoreContext();

            //StockBalances = new ObservableCollection<StockBalance>(
            //StockBalances = new ObservableCollection<string>(
                //db.StockBalances.Select(sb => sb.Stockbalances).ToList()

            StoreNames = new ObservableCollection<string>(
                db.Stores.Select(s => s.Name).Distinct().ToList()
            );
        }

    }
}

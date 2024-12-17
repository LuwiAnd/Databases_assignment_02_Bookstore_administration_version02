using Bookstore.Domain;
using Bookstore.Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
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
        

        //ObservableCollection<StockBalance> StockBalances { get; private set; } // Motsvarande denna kodrad fungerar för Fredrik, men den fungerar inte för mig (CompanyDemo_del3 14:00).
        //ObservableCollection<StockBalance> StockBalances { get; set; }
        //ObservableCollection<string> StockBalances { get; set; }
        //ObservableCollection<int> StockBalances { get; set; }
        public ObservableCollection<string> StoreNames { get; set; }

        private string? _selectedStore;

        public string? SelectedStore
        {
            //get { return _selectedStore; } // Detta är samma som nedanstående sätt att skriva get på.
            get => _selectedStore;
            set {
                _selectedStore = value;
                RaisePropertyChanged();
                LoadStockBalances();
                RaisePropertyChanged("StockBalances");
            }
        }


        public ObservableCollection<StockBalance> StockBalances { get; private set; }




        public MainWindowViewModel()
        {
            
            LoadStores();
            //LoadStockBalances();
        }
        private void LoadStores()
        {
            using var db = new BookStoreContext();

            //StockBalances = new ObservableCollection<StockBalance>(
            //StockBalances = new ObservableCollection<string>(
                //db.StockBalances.Select(sb => sb.Stockbalances).ToList()

            StoreNames = new ObservableCollection<string>(
                db.Stores.Select(s => s.Name).Distinct().ToList()
            );

            SelectedStore = StoreNames.FirstOrDefault();
        }


        private void LoadStockBalances()
        {
            using var db = new BookStoreContext();

            //var testc = db.StockBalances;

            ///**/
            //StockBalances = new ObservableCollection<StockBalance>(
            //    db.StockBalances.ToList()
            //);
            ///**/

            //SelectedStore = StoreNames.FirstOrDefault(); // Denna kodrad orsakade en evig loop som ledde till stack overflow, för att en property-set-funktion anropade denna som anropade set-funktionen som anropade denna funktion, som anropade ...

            //var stockBalances = db.StockBalances
            //var filteredStockBalances = db.StockBalances
            StockBalances = new ObservableCollection<StockBalance>(
                db.StockBalances
                .Include(sb => sb.Store)
                .Include(sb => sb.Isbn13Navigation)
                .Where(sb => sb.Store.Name == SelectedStore)
            );

            /*
            //StockBalances = new ObservableCollection<StockBalance>(stockBalances);
            StockBalances.Clear();
            foreach(var stockBalance in filteredStockBalances)
            {
                StockBalances.Add(stockBalance);
            }
            */


            //var stockBalancesWithStoreNames = db.StockBalances
            //    .Join(
            //        db.Stores, // Tabellen att slå ihop med
            //        db.StockBalances

            //        /*
            //        sb => sb.StoreID, // Nyckel i StockBalances
            //        s => s.storeID,   // Nyckel i Stores
            //        (sb, s) => new // Projektionsresultat
            //        {
            //            StoreName = s.Name,
            //            sb.ISBN13,
            //            sb.Count
            //        }
            //    ).ToList();
            //*/
        }

    }
}

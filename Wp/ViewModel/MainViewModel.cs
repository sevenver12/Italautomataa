using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wp.Helper;
using Wp.Interfaces;
using Wp.Modell;
using Wp.Services;

namespace Wp.ViewModel
{
    public class MainViewModel : Observable
    {
        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<Moneyy> Pouch { get; }
        public ObservableCollection<Moneyy> ToReturn { get; }


        private int _currentMoney;
        public int CurrentMoney
        {
            get { return _currentMoney; }
            set { Set(ref _currentMoney, value); }
        }
        private int _bank;
        public string BankFT
        {
            get { return _bank + " ft"; }
        }

        IMoneyHandler moneyHandler = new MoneyHandler();
        IProductHandler productHandler = new ProductHandler();
        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();
            Pouch = new ObservableCollection<Moneyy>();
            ToReturn = new ObservableCollection<Moneyy>();
            moneyHandler.FillMoneyPouch(Pouch, true);
            productHandler.GetProducts(Products);


        }
        private ICommand _moneyInstalled;

        public ICommand MoneyInstalledCommand
        {
            get { return _moneyInstalled = _moneyInstalled ?? new RelayCommand(param => InstallMoney(Convert.ToInt32(param))); }
        }
        public void InstallMoney(int money)
        {
            if (ToReturn.Any()) ToReturn.Clear();
            if (CurrentMoney < 1000)
            {
                CurrentMoney += money;
                moneyHandler.InstallMoney(Pouch, ref _bank, money);
                OnPropertyChanged(nameof(BankFT));
                ((RelayCommand)ProductPurchaseCommand).RaiseCanExecuteChanged();
            }

        }

        private ICommand _productPurchase;

        public ICommand ProductPurchaseCommand
        {
            get { return _productPurchase = _productPurchase ?? new RelayCommand(param => PurchaseProduct((Product)param), param => ((Product)param)?.Price <= CurrentMoney); }
        }
        public void PurchaseProduct(Product item)
        {
            CurrentMoney -= item.Price;
            if (CurrentMoney > 0)
            { 
                foreach (var fe in moneyHandler.ReturnMoney(Pouch, CurrentMoney))
                {
                    ToReturn.Add(fe);
                }
                CurrentMoney = 0;
            }
            OnPropertyChanged(nameof(BankFT));
            ((RelayCommand)ProductPurchaseCommand).RaiseCanExecuteChanged();
        }
    }
}

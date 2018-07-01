using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NWind.ViewModel
{
    public class ProductModel : INotifyPropertyChanged
    {
        private int _categoryID;
        public int CategoryID
        {
            get { return _categoryID; }
            set
            {
                if (_categoryID != value)
                {
                    _categoryID = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private int _productID;
        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (_productID != value)
                {
                    _productID = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _unitsInStock;
        public decimal UnitsInStock
        {
            get { return _unitsInStock; }
            set
            {
                if (_unitsInStock != value)
                {
                    _unitsInStock = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (_unitPrice != value)
                {
                    _unitPrice = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

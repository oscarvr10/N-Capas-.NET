using System.Collections.Generic;

namespace NWind.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        public ProductViewModel()
        {
            InitializeViewModel();
        }

        #region Properties
        
        private List<Entities.Product> _products;
        public List<Entities.Product> Products
        {
            get { return _products; }
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged();
                }
            }
        }

        private Entities.Product _selectedProduct;
        public Entities.Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged();
                }
            }
        }

        private ProductModel _productModel;
        public ProductModel ProductDetail
        {
            get { return _productModel; }
            set
            {
                _productModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public CommandDelegate SearchProductsCommand { get; set; }
        public CommandDelegate SearchProductByIDCommand { get; set; }
        public CommandDelegate NewProductCommand { get; set; }
        #endregion

        private void InitializeViewModel()
        {
            Products = new List<Entities.Product>();
            ProductDetail = new ProductModel();
            SearchProductsCommand = new CommandDelegate
                (
                    (obj) => { return true; },
                    (obj) => 
                    {
                        var proxy = new NWindProxyService.Proxy();
                        Products = proxy.GetProductsByCategoryID(ProductDetail.CategoryID);
                    }
                );
            SearchProductByIDCommand = new CommandDelegate
                (
                    (obj) => { return true; },
                    (obj) =>
                    {
                        if (SelectedProduct.ProductID == 0) return;

                        var proxy = new NWindProxyService.Proxy();
                        var product = proxy.GetProductByID(SelectedProduct.ProductID);
                        ProductDetail.ProductName = product.ProductName;
                        ProductDetail.ProductID = product.ProductID;
                        ProductDetail.UnitsInStock = product.UnitsInStock;
                        ProductDetail.UnitPrice = product.UnitPrice;
                    }
                );
        }
    }
}

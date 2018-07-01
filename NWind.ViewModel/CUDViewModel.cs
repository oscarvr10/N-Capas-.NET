namespace NWind.ViewModel
{
    public class CUDViewModel : ViewModelBase
    {
        private bool _hasError;
        public bool HasError
        {
            get { return _hasError; }
            set
            {
                _hasError = value;
                OnPropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        private ProductModel _product;
        public ProductModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }

        public CommandDelegate CreateProductCommand { get; set; }
        public CommandDelegate UpdateProductCommand { get; set; }
        public CommandDelegate DeleteProductCommand { get; set; }

        public CUDViewModel()
        {
            InitializeViewModel();
        }

        private void InitializeViewModel()
        {
            Product = new ProductModel();
            CreateProductCommand = new CommandDelegate
                (
                    (obj) => { return true; },
                    (obj) =>
                    {
                        var newProduct = new Entities.Product()
                        {
                            CategoryID = Product.CategoryID,
                            ProductName = Product.ProductName,
                            UnitPrice = Product.UnitPrice,
                            UnitsInStock = Product.UnitsInStock
                        };
                        var proxy = new NWindProxyService.Proxy();
                        newProduct = proxy.CreateProduct(newProduct);
                        Product.ProductID = newProduct.ProductID;
                    }
                );
            UpdateProductCommand = new CommandDelegate
                (
                    (obj) => { return true; },
                    (obj) =>
                    {
                        var updateProduct = new Entities.Product()
                        {
                            ProductID = Product.ProductID,
                            CategoryID = Product.CategoryID,
                            ProductName = Product.ProductName,
                            UnitPrice = Product.UnitPrice,
                            UnitsInStock = Product.UnitsInStock
                        };
                        var proxy = new NWindProxyService.Proxy();
                        var updated = proxy.UpdateProduct(updateProduct);

                        if (updated)
                        {
                            HasError = false;
                            Message = "The product has been updated correctly.";
                        }
                        else
                        {
                            HasError = true;
                            Message = "The product could not be updated.";
                        }
                    }
                );
            DeleteProductCommand = new CommandDelegate
                (
                    (obj) => { return true; },
                    (obj) =>
                    {
                        var proxy = new NWindProxyService.Proxy();
                        var deleted = proxy.DeleteProduct(Product.ProductID);
                        if (deleted)
                        {
                            HasError = false;
                            Product = new ProductModel();
                            Message = "The product has been deleted correctly.";
                        }
                        else
                        {
                            HasError = true;
                            Message = "The product could not be deleted.";
                        }
                    }
                );
        }
    }
}

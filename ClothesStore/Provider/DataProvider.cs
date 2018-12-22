using ClothesStore.Domain;
using System.Collections.Generic;

namespace ClothesStore.Provider
{
    public class DataProvider
    {
        public List<Supplier> suppliers;
        public List<Customer> customers;
        public List<Rate> rates;
        public List<Color> colors;
        public List<Size> sizes;
        public List<Clothes> clothes;
        public List<ClothesType> clothesTypes;
        public List<ClothesColor> clothesColors;
        public List<ClothesSize> clothesSizes;
        public List<ClothesRate> clothesRates;
        public List<Stock> stocks;
        public List<SellingOrder> sellingOrders;
        public List<SellingOrderDetail> sellingOrderDetails;
        public List<SupplierOrder> supplierOrders;
        public List<SupplierOrderDetail> supplierOrderDetails;

        public DataProvider()
        {
            InitData();
        }

        private void InitData()
        {
            suppliers = new List<Supplier>
            {
                new Supplier { Id = 1, Name = "Supplier 1" },
                new Supplier { Id = 2, Name = "Supplier 2" },
                new Supplier { Id = 3, Name = "Supplier 3" },
                new Supplier { Id = 4, Name = "Supplier 4" }
            };

            rates = new List<Rate>
            {
                new Rate { Id = 1, Name = "Supplier Rate" },
                new Rate { Id = 2, Name = "Selling Rate" }
            };

            clothesTypes = new List<ClothesType>
            {
                new ClothesType { Id = 1, Name = "Shirt" },
                new ClothesType { Id = 2, Name = "Trousers" }
            };

            colors = new List<Color>
            {
                new Color { Id = 1, Name = "Red" },
                new Color { Id = 2, Name = "Blue" },
                new Color { Id = 3, Name = "Yellow" },
                new Color { Id = 4, Name = "Green" },
                new Color { Id = 5, Name = "White" },
                new Color { Id = 6, Name = "Black" }
            };

            sizes = new List<Size>
            {
                new Size { Id = 1, Name = "XS" },
                new Size { Id = 2, Name = "S" },
                new Size { Id = 3, Name = "M" },
                new Size { Id = 4, Name = "L" },
                new Size { Id = 5, Name = "XL" },
                new Size { Id = 6, Name = "XXL" }
            };

            customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1", Address = "Address 1", Email = "Email 1", Phone = "Phone 1" },
                new Customer { Id = 2, Name = "Customer 2", Address = "Address 2", Email = "Email 2", Phone = "Phone 2" },
                new Customer { Id = 3, Name = "Customer 3", Address = "Address 3", Email = "Email 3", Phone = "Phone 3" },
                new Customer { Id = 4, Name = "Customer 4", Address = "Address 4", Email = "Email 4", Phone = "Phone 4" },
                new Customer { Id = 5, Name = "Customer 5", Address = "Address 5", Email = "Email 5", Phone = "Phone 5" }
            };

            clothes = new List<Clothes>
            {
                new Clothes { Id = 1, Name = "T-Shirt", SupplierId = 1, TypeId = 1 },
                new Clothes { Id = 2, Name = "Dress Shirt", SupplierId = 1, TypeId = 1 },
                new Clothes { Id = 3, Name = "Sleeve Shirt", SupplierId = 2, TypeId = 1 },
                new Clothes { Id = 4, Name = "Overshirt", SupplierId = 2, TypeId = 1 },
                new Clothes { Id = 5, Name = "Khakis ", SupplierId = 3, TypeId = 2 },
                new Clothes { Id = 6, Name = "Chinos", SupplierId = 3, TypeId = 2 },
                new Clothes { Id = 7, Name = "Trousers", SupplierId = 4, TypeId = 2 },
                new Clothes { Id = 8, Name = "Short", SupplierId = 4, TypeId = 2 },
            };

            clothesColors = new List<ClothesColor>
            {
                new ClothesColor { Id = 1, ClothesId = 1, ColorId = 1 },
                new ClothesColor { Id = 2, ClothesId = 1, ColorId = 2 },
                new ClothesColor { Id = 3, ClothesId = 1, ColorId = 3 },
                new ClothesColor { Id = 4, ClothesId = 1, ColorId = 4 },
                new ClothesColor { Id = 5, ClothesId = 2, ColorId = 1 },
                new ClothesColor { Id = 6, ClothesId = 2, ColorId = 2 },
                new ClothesColor { Id = 7, ClothesId = 3, ColorId = 3 },
                new ClothesColor { Id = 8, ClothesId = 3, ColorId = 4 },
                new ClothesColor { Id = 9, ClothesId = 3, ColorId = 5 },
                new ClothesColor { Id = 10, ClothesId = 4, ColorId = 5 },
                new ClothesColor { Id = 11, ClothesId = 4, ColorId = 6 },
                new ClothesColor { Id = 12, ClothesId = 5, ColorId = 5 },
                new ClothesColor { Id = 13, ClothesId = 5, ColorId = 6 },
                new ClothesColor { Id = 14, ClothesId = 6, ColorId = 1 },
                new ClothesColor { Id = 15, ClothesId = 6, ColorId = 4 },
                new ClothesColor { Id = 16, ClothesId = 7, ColorId = 1 },
                new ClothesColor { Id = 17, ClothesId = 7, ColorId = 3 },
                new ClothesColor { Id = 18, ClothesId = 8, ColorId = 2 },
                new ClothesColor { Id = 19, ClothesId = 8, ColorId = 6 }
            };

            clothesSizes = new List<ClothesSize>
            {
                new ClothesSize { Id = 1, ClothesId = 1, SizeId = 1 },
                new ClothesSize { Id = 2, ClothesId = 1, SizeId = 2 },
                new ClothesSize { Id = 3, ClothesId = 1, SizeId = 3 },
                new ClothesSize { Id = 4, ClothesId = 1, SizeId = 4 },
                new ClothesSize { Id = 5, ClothesId = 2, SizeId = 1 },
                new ClothesSize { Id = 6, ClothesId = 2, SizeId = 2 },
                new ClothesSize { Id = 7, ClothesId = 3, SizeId = 3 },
                new ClothesSize { Id = 8, ClothesId = 3, SizeId = 4 },
                new ClothesSize { Id = 9, ClothesId = 3, SizeId = 5 },
                new ClothesSize { Id = 10, ClothesId = 4, SizeId = 3 },
                new ClothesSize { Id = 11, ClothesId = 4, SizeId = 4 },
                new ClothesSize { Id = 12, ClothesId = 5, SizeId = 4 },
                new ClothesSize { Id = 13, ClothesId = 5, SizeId = 5 },
                new ClothesSize { Id = 14, ClothesId = 6, SizeId = 1 },
                new ClothesSize { Id = 15, ClothesId = 6, SizeId = 4 },
                new ClothesSize { Id = 16, ClothesId = 7, SizeId = 1 },
                new ClothesSize { Id = 17, ClothesId = 7, SizeId = 3 },
                new ClothesSize { Id = 18, ClothesId = 8, SizeId = 2 },
                new ClothesSize { Id = 19, ClothesId = 8, SizeId = 5 }
            };

            clothesRates = new List<ClothesRate>
            {
                new ClothesRate { Id = 1, ClothesId = 1, RateId = 1, Price = 6 }, // T-Shirt: $6
                new ClothesRate { Id = 1, ClothesId = 1, RateId = 2, Price = 12 }, // T-Shirt: $12
                new ClothesRate { Id = 1, ClothesId = 2, RateId = 1, Price = 8 }, // Dress Shirt: $8
                new ClothesRate { Id = 1, ClothesId = 2, RateId = 2, Price = 20 } // Dress Shirt: $20
            };
        }
    }
}

using ClothesStore.Domain;
using ClothesStore.Provider;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClothesStore
{
    public class Processor
    {
        private readonly DataProvider _dataProvider;

        public Processor()
        {
            _dataProvider = new DataProvider();
        }

        public void Run()
        {
            RunSupplierProcess();
            RunCustomerProcess();
        }

        private void RunSupplierProcess()
        {
            var supplierRate = _dataProvider.rates.Get(1);
            if (supplierRate == null)
            {
                throw new Exception("Rate does not exist");
            }

            Console.WriteLine("------ Buy clothes from Supplier 1");
            Console.WriteLine("Clothes: T-Shirt, Color: Red, Size: XS, Type: Shirt, Quantity: 2");
            BuyClothesFromSupplier(clothesId: 1, colorId: 1, sizeId: 1, clothesTypeId: 1, supplierId: 1, quantity: 2, rate: supplierRate);

            Console.WriteLine("Clothes: T-Shirt, Color: Red, Size: S, Type: Shirt, Quantity: 4");
            BuyClothesFromSupplier(clothesId: 1, colorId: 1, sizeId: 2, clothesTypeId: 1, supplierId: 1, quantity: 4, rate: supplierRate);

            Console.WriteLine("Clothes: T-Shirt, Color: Red, Size: M, Type: Shirt, Quantity: 5");
            BuyClothesFromSupplier(clothesId: 1, colorId: 1, sizeId: 3, clothesTypeId: 1, supplierId: 1, quantity: 5, rate: supplierRate);

            Console.WriteLine("Clothes: T-Shirt, Color: Yellow, Size: S, Type: Shirt, Quantity: 2");
            BuyClothesFromSupplier(clothesId: 1, colorId: 3, sizeId: 2, clothesTypeId: 1, supplierId: 1, quantity: 2, rate: supplierRate);

            Console.WriteLine("Clothes: T-Shirt, Color: Yellow, Size: M, Type: Shirt, Quantity: 4");
            BuyClothesFromSupplier(clothesId: 1, colorId: 3, sizeId: 3, clothesTypeId: 1, supplierId: 1, quantity: 4, rate: supplierRate);

            Console.WriteLine("Clothes: T-Shirt, Color: Yellow, Size: L, Type: Shirt, Quantity: 5");
            BuyClothesFromSupplier(clothesId: 1, colorId: 3, sizeId: 4, clothesTypeId: 1, supplierId: 1, quantity: 5, rate: supplierRate);

            Console.WriteLine("------ Buy clothes from Supplier 2");
            Console.WriteLine("Clothes: Dress Shirt, Color: Blue, Size: S, Type: Shirt, Quantity: 6");
            BuyClothesFromSupplier(clothesId: 2, colorId: 2, sizeId: 2, clothesTypeId: 2, supplierId: 2, quantity: 6, rate: supplierRate);

            Console.WriteLine("Clothes: Dress Shirt, Color: Blue, Size: M, Type: Shirt, Quantity: 3");
            BuyClothesFromSupplier(clothesId: 2, colorId: 2, sizeId: 3, clothesTypeId: 3, supplierId: 2, quantity: 3, rate: supplierRate);

            Console.WriteLine("Clothes: Dress Shirt, Color: Blue, Size: XL, Type: Shirt, Quantity: 4");
            BuyClothesFromSupplier(clothesId: 2, colorId: 2, sizeId: 5, clothesTypeId: 1, supplierId: 2, quantity: 4, rate: supplierRate);

            Console.WriteLine("Clothes: Dress Shirt, Color: Green, Size: XS, Type: Shirt, Quantity: 6");
            BuyClothesFromSupplier(clothesId: 2, colorId: 4, sizeId: 1, clothesTypeId: 2, supplierId: 2, quantity: 6, rate: supplierRate);

            Console.WriteLine("Clothes: Dress Shirt, Color: Green, Size: L, Type: Shirt, Quantity: 3");
            BuyClothesFromSupplier(clothesId: 2, colorId: 4, sizeId: 4, clothesTypeId: 3, supplierId: 2, quantity: 3, rate: supplierRate);

            Console.WriteLine("Clothes: Dress Shirt, Color: Green, Size: XXL, Type: Shirt, Quantity: 4");
            BuyClothesFromSupplier(clothesId: 2, colorId: 4, sizeId: 6, clothesTypeId: 1, supplierId: 2, quantity: 4, rate: supplierRate);

            Console.WriteLine("Approve all new supplier order and add to stock");
            var newSupplierOrders = _dataProvider.supplierOrders.GetBy(x => x.Status == OrderStatus.New).OrderBy(x => x.Id).ToList();
            foreach (var order in newSupplierOrders)
            {
                ApproveSupplierOrderAndAddToStock(order.Id, supplierRate);
            }
        }

        private void RunCustomerProcess()
        {
            var sellingRate = _dataProvider.rates.Get(2);
            if (sellingRate == null)
            {
                throw new Exception("Rate does not exist");
            }

            Console.WriteLine("------ Sell clothes to Customer 1");
            Console.WriteLine("Clothes: T-Shirt, Color: Red, Size: XS, Quantity: 2");
            SellClothesToCustomer(clothesId: 1, colorId: 1, sizeId: 1, customerId: 1, quantity: 2, rate: sellingRate);
            ApproveSellingOrder(sellingRate);

            Console.WriteLine("Clothes: T-Shirt, Color: Red, Size: XS, Quantity: 2");
            SellClothesToCustomer(clothesId: 1, colorId: 1, sizeId: 2, customerId: 1, quantity: 2, rate: sellingRate);
            ApproveSellingOrder(sellingRate);

            // Will raise exeption because T-Shirt with color red, size XS, quantity is out of stock
            Console.WriteLine("Clothes: T-Shirt, Color: Blue, Size: XS, Quantity: 3");
            SellClothesToCustomer(clothesId: 1, colorId: 1, sizeId: 2, customerId: 1, quantity: 3, rate: sellingRate);
            ApproveSellingOrder(sellingRate);

            // Will raise exeption because stock does not exist Dress Shirt with black color
            Console.WriteLine("Clothes: Dress Shirt, Color: Black, Size: XS, Quantity: 1");
            SellClothesToCustomer(clothesId: 2, colorId: 6, sizeId: 2, customerId: 1, quantity: 2, rate: sellingRate);
            ApproveSellingOrder(sellingRate);

            // Will raise exeption because stock does not Dress Shirt with color green and size S
            Console.WriteLine("Clothes: Dress Shirt, Color: Green, Size: S, Quantity: 5");
            SellClothesToCustomer(clothesId: 2, colorId: 4, sizeId: 2, customerId: 1, quantity: 2, rate: sellingRate);
            ApproveSellingOrder(sellingRate);
        }

        private void ApproveSellingOrder(Rate rate)
        {
            // Approve all new selling order and add out of stock
            var newSellingOrders = _dataProvider.sellingOrders.GetBy(x => x.Status == OrderStatus.New);
            foreach (var order in newSellingOrders)
            {
                ApproveSellingOrderAndAddOutOfStock(order.Id, rate);
            }
        }

        private void BuyClothesFromSupplier(int clothesId, int colorId, int sizeId, int clothesTypeId, int supplierId, int quantity, Rate rate)
        {
            Console.WriteLine("-- Vendor buy clothing from supplier");

            var selectedSupplier = _dataProvider.suppliers.GetAll().Get(supplierId);
            Console.WriteLine($"+ Select supplier - Id: {selectedSupplier.Id}, Name: {selectedSupplier.Name}");

            var selectedClothes = _dataProvider.clothes.GetAll().Get(clothesId);
            Console.WriteLine($"+ Select clothes - Id: {selectedClothes.Id}, Name: {selectedClothes.Name}");

            var selectedClothesType = _dataProvider.clothes.GetAll().Get(clothesTypeId);
            Console.WriteLine($"+ Select clothes type - Id: {selectedClothesType.Id}, Name: {selectedClothesType.Name}");

            var selectedColor = _dataProvider.colors.GetAll().Get(colorId);
            Console.WriteLine($"+ Select color - Id: {selectedColor.Id}, Name: {selectedColor.Name}");

            var selectedSize = _dataProvider.sizes.GetAll().Get(sizeId);
            Console.WriteLine($"+ Select size - Id: {selectedSize.Id}, Name: {selectedSize.Name}");

            ExecuteSupplierOrderAction(colorId, sizeId, quantity, selectedSupplier, selectedClothes, rate);

            Console.WriteLine("-- End process buy clothing from supplier");
        }

        private void ExecuteSupplierOrderAction(int colorId, int sizeId, int quantity, Supplier selectedSupplier, Clothes selectedClothes, Rate rate)
        {
            int supplierId = selectedSupplier.Id;
            int clothesId = selectedClothes.Id;
            string clothesName = selectedClothes.Name;

            Console.WriteLine("# Create supplier order: ");
            var newOrder = new SupplierOrder
            {
                ClothesId = clothesId,
                SupplierId = supplierId,
                Status = OrderStatus.New,
                OrderDate = DateTime.Now
            };
            Console.WriteLine($"+ New supplier order - Id: {newOrder.Id}, Order date: {newOrder.OrderDate}, Supplier Id: {supplierId}, Supplier Name: {selectedSupplier.Name}");

            var tempSupplierOrders = _dataProvider.supplierOrders.GetAll();
            var tempSupplierOrderDetail = _dataProvider.supplierOrderDetails.GetAll();

            Console.WriteLine("+ Save temp order");
            TransactionProvider.ExecuteOperationInTransaction(() =>
            {
                Console.WriteLine("# Create supplier order detail");

                var buyingRateByClothes = _dataProvider.clothesRates.GetBy(x => x.ClothesId == selectedClothes.Id && x.RateId == rate.Id).FirstOrDefault();
                if (buyingRateByClothes == null)
                {
                    throw new Exception("Buying rate does not exist for clothes");
                }

                int newOrderId = tempSupplierOrders.Add<SupplierOrder>(newOrder);
                var newOrderDetail = new SupplierOrderDetail
                {
                    OrderId = newOrderId,
                    ClothesId = clothesId,
                    ColorId = colorId,
                    SizeId = sizeId,
                    Quantity = quantity,
                    TotalPrice = quantity * buyingRateByClothes.Price
                };
                tempSupplierOrderDetail.Add(newOrderDetail);

                Console.WriteLine($"+ New supplier order detail - OrderId: {newOrderDetail.OrderId}, Clothes Id: {clothesId}, Clothes Name: {clothesName}, Quantity: {newOrderDetail.Quantity}, TotalPrice: {newOrderDetail.TotalPrice}");
            });

            Console.WriteLine("+ Save actual order");
            _dataProvider.supplierOrders = tempSupplierOrders;
            _dataProvider.supplierOrderDetails = tempSupplierOrderDetail;
        }

        private void ApproveSupplierOrderAndAddToStock(int orderId, Rate rate)
        {
            var order = _dataProvider.supplierOrders.Get(orderId);
            if (order == null)
            {
                throw new Exception("Order does not exists");
            }

            var tempSupplierOrders = _dataProvider.supplierOrders.GetAll();
            var tempSupplierOrderDetails = _dataProvider.supplierOrderDetails.GetAll();
            var tempStocks = _dataProvider.stocks.GetAll();

            TransactionProvider.ExecuteOperationInTransaction(() =>
            {
                tempSupplierOrders = ApproveSupplierOrder(orderId, tempSupplierOrders);

                var completedSupplierOrders = tempSupplierOrders.Where(x => x.Id == orderId && x.Status == OrderStatus.Complete);
                var completedSupplierOrderDetails = tempSupplierOrderDetails.Where(x => completedSupplierOrders.Any(o => o.Id == x.OrderId)).ToList();

                tempStocks = AddClothesToStock(completedSupplierOrderDetails, rate, tempStocks);
            });

            _dataProvider.supplierOrders = tempSupplierOrders;
            _dataProvider.stocks = tempStocks;
        }

        private List<SupplierOrder> ApproveSupplierOrder(int orderId, List<SupplierOrder> orders)
        {
            var orderToApprove = _dataProvider.supplierOrders.Get(orderId);
            if (orderToApprove == null)
            {
                throw new Exception("Order does not exist");
            }

            orderToApprove.Status = OrderStatus.Complete;
            var newOrders = orders.Edit(orderToApprove, orderId);

            return newOrders;
        }

        private List<Stock> AddClothesToStock(List<SupplierOrderDetail> orderDetails, Rate rate, List<Stock> stocks)
        {
            Console.WriteLine("+ Add clothes to stock when buying clothes from supplier");

            foreach (var orderDetail in orderDetails)
            {
                stocks.Add(new Stock
                {
                    ClothesId = orderDetail.ClothesId,
                    ColorId = orderDetail.ColorId,
                    SizeId = orderDetail.SizeId,
                    RateId = rate.Id,
                    Quantity = orderDetail.Quantity,
                    QuantityType = QuantityType.Input
                });
            }

            return stocks;
        }

        private void SellClothesToCustomer(int clothesId, int colorId, int sizeId, int customerId, int quantity, Rate rate)
        {
            Console.WriteLine("-- Vendor sell clothing to customer");

            var selectedClothes = _dataProvider.clothes.GetAll().Get(clothesId);
            Console.WriteLine($"+ Select Clothes - Id: {selectedClothes.Id}, Name: {selectedClothes.Name}");

            bool isExistClothesInStock = CheckExistClothesInStock(selectedClothes.Id, colorId, sizeId, quantity);
            if (!isExistClothesInStock)
            {
                throw new Exception($"Clothes - Id: {selectedClothes.Id}, Name: {selectedClothes.Name} is empty in stock or quantity order is out of stock.");
            }

            var selectedCustomer = _dataProvider.customers.GetAll().Get(customerId);
            Console.WriteLine($"+ Select Customer - Id: {selectedCustomer.Id}, Name: {selectedCustomer.Name}");

            var selectedColor = _dataProvider.colors.GetAll().Get(colorId);
            Console.WriteLine($"+ Select color - Id: {selectedColor.Id}, Name: {selectedColor.Name}");

            var selectedSize = _dataProvider.sizes.GetAll().Get(sizeId);
            Console.WriteLine($"+ Select size - Id: {selectedSize.Id}, Name: {selectedSize.Name}");

            ExecuteSellingOrderAction(colorId, sizeId, quantity, selectedCustomer, selectedClothes, rate);

            Console.WriteLine("-- End process vendor sell clothing to customer");
        }

        private void ExecuteSellingOrderAction(int colorId, int sizeId, int quantity, Customer selectedCustomer, Clothes selectedClothes, Rate rate)
        {
            int customerId = selectedCustomer.Id;
            int clothesId = selectedClothes.Id;
            string clothesName = selectedClothes.Name;

            Console.WriteLine("# Create selling order: ");
            var newOrder = new SellingOrder
            {
                SupplierId = selectedClothes.SupplierId,
                CustomerId = customerId,
                Status = OrderStatus.New,
                OrderDate = DateTime.Now
            };
            Console.WriteLine($"+ New selling order - Id: {newOrder.Id}, Order date: {newOrder.OrderDate}, CustomerId Id: {customerId}, CustomerId Name: {selectedCustomer.Name}");

            var tempSellingOrders = _dataProvider.sellingOrders.GetAll();
            var tempSellingOrderDetail = _dataProvider.sellingOrderDetails.GetAll();

            Console.WriteLine("+ Save temp order");
            TransactionProvider.ExecuteOperationInTransaction(() =>
            {
                int newOrderId = tempSellingOrders.Add<SellingOrder>(newOrder);

                var sellingRateByClothes = _dataProvider.clothesRates.GetBy(x => x.ClothesId == selectedClothes.Id && x.RateId == rate.Id).FirstOrDefault();
                if (sellingRateByClothes == null)
                {
                    throw new Exception("Selling rate does not exist for clothes");
                }

                Console.WriteLine("# Create selling order detail");

                var newOrderDetail = new SellingOrderDetail
                {
                    OrderId = newOrderId,
                    ClothesId = clothesId,
                    ColorId = colorId,
                    SizeId = sizeId,
                    Quantity = quantity,
                    TotalPrice = quantity * sellingRateByClothes.Price
                };
                tempSellingOrderDetail.Add(newOrderDetail);

                Console.WriteLine($"+ New selling order detail - OrderId: {newOrderDetail.OrderId}, Clothes Id: {clothesId}, Clothes Name: {clothesName}, Quantity: {newOrderDetail.Quantity}, TotalPrice: {newOrderDetail.TotalPrice}");
            });

            Console.WriteLine("+ Save actual order");
            _dataProvider.sellingOrders = tempSellingOrders;
            _dataProvider.sellingOrderDetails = tempSellingOrderDetail;

            Console.WriteLine("+ Approve order and add to stock");
        }

        private void ApproveSellingOrderAndAddOutOfStock(int orderId, Rate rate)
        {
            var order = _dataProvider.supplierOrders.Get(orderId);
            if (order == null)
            {
                throw new Exception("Order does not exists");
            }

            var tempSellingOrders = _dataProvider.sellingOrders.GetAll();
            var tempSellingOrderDetails = _dataProvider.sellingOrderDetails.GetAll();
            var tempStocks = _dataProvider.stocks.GetAll();

            TransactionProvider.ExecuteOperationInTransaction(() =>
            {
                tempSellingOrders = ApproveSellingOrder(orderId, tempSellingOrders);

                var completedSellingOrders = tempSellingOrders.Where(x => x.Id == orderId && x.Status == OrderStatus.Complete);
                var completedSellingOrderDetails = tempSellingOrderDetails.Where(x => completedSellingOrders.Any(o => o.Id == x.OrderId)).ToList();
                
                tempStocks = AddClothesOutOfStock(completedSellingOrderDetails, rate, tempStocks);
            });

            _dataProvider.sellingOrders = tempSellingOrders;
            _dataProvider.stocks = tempStocks;
        }

        private List<SellingOrder> ApproveSellingOrder(int orderId, List<SellingOrder> orders)
        {
            var orderToApprove = _dataProvider.sellingOrders.Get(orderId);
            if (orderToApprove == null)
            {
                throw new Exception("Order does not exist");
            }

            orderToApprove.Status = OrderStatus.Complete;
            var newOrders = orders.Edit(orderToApprove, orderId);

            return newOrders;
        }

        private List<Stock> AddClothesOutOfStock(List<SellingOrderDetail> orderDetails, Rate rate, List<Stock> stocks)
        {
            Console.WriteLine("+ Add clothes to stock when selling clothes to customer");

            foreach (var orderDetail in orderDetails)
            {
                stocks.Add(new Stock
                {
                    ClothesId = orderDetail.ClothesId,
                    RateId = rate.Id,
                    ColorId = orderDetail.ColorId,
                    SizeId = orderDetail.SizeId,
                    Quantity = orderDetail.Quantity,
                    QuantityType = QuantityType.Output
                });
            }

            return stocks;
        }

        private bool CheckExistClothesInStock(int clothesId, int colorId, int sizeId, int quantity)
        {
            var inputClothesStock = _dataProvider.stocks.GetBy(x => x.QuantityType == QuantityType.Input);
            if (inputClothesStock.Count == 0)
            {
                return false;
            }

            var existedClothesInStock = _dataProvider.stocks.GetBy(x => x.ClothesId == clothesId && x.ColorId == colorId && x.SizeId == sizeId);

            var numberInputQuantity = existedClothesInStock.Where(x => x.QuantityType == QuantityType.Input).Sum(x => x.Quantity);
            var numberOutputQuantity = existedClothesInStock.Where(x => x.QuantityType == QuantityType.Output).Sum(x => x.Quantity);

            return numberInputQuantity - (numberOutputQuantity + quantity) >= 0;
        }
    }
}

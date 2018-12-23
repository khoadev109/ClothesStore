using System;
using ClothesStore.Domain;
using ClothesStore.Provider;

namespace ClothesStore
{
    class Program
    {
        /// <summary>
        ///  Buy clothing from suppliers and selling that clothing customers
        ///  
        ///  Scale to support new kinds of clothing other than shirts
        ///  
        ///  Handle ordering from different suppliers
        ///  
        ///  Extends app to be able to handle more rate types: wholesale rate, discount rate,...
        ///  - Purpose:
        ///     + Can store in stock more rate type of clothes without breaking current system
        ///  - Description:
        ///     + Current stock includes 2 rate's types:
        ///         * When buying clothes from supplier, rate type is: Input
        ///         * When selling clothes to customer, rate type is: Output
        ///         * Base on these types can get approriate rate of clothes:
        ///             => Selling rate: T-Shirt - $6 
        ///             => Retail rate: T-Shirt - $12
        ///     + When add more rate like wholesale rate:
        ///         * Can get approriate rate of clothes:
        ///             => Selling rate: T-Shirt - $6 
        ///             => Retail rate: T-Shirt - $12
        ///             => Wholesale rate: T-shirt - $10
        ///         
        ///  Extends app to be able to handle more quantity types: non-charge quantity,...
        ///  - Purpose:
        ///     + Can store in stock more quantity type of clothes without breaking current system
        ///     + To prevent update quantity of clothes in stock on specific record
        ///  - Description:
        ///     + Current stock includes 2 quantity's types:
        ///         * Input quantity type: quantity of buying clothes from supplier
        ///         * Output quantity type: quantity of selling clothes to customer
        ///         * When selling clothes to customer, the calculation of checking existing clothes in stock will be:
        ///             => currentInputQuantity - (currentOutputQuantity + quantityInputOfCustomer) >= 0
        ///     + When add more quantity like discount quantity:
        ///         * The calculation will be: 
        ///             => currentInputQuantity - (currentOutputQuantity + quantityInputOfCustomer + discountQuantity) >= 0
        ///             
        ///   For quantity type, current is store all stock's data in one object and distinguish data by quantity type. 
        ///   So another approach is separate stock's data into single object:
        ///     + A single object like StockInput: store clothes's data in stock have input quantity type
        ///     + A single object like StockOutput: store clothes's data in stock have output quantity type
        ///     + A single object like StockDiscount: store clothes's data in stock have discount quantity type
        ///   Purpose:
        ///    - Prevent large data issue when storing data in one object
        ///    - Can get data from separate objects and calculate quantity more faster
        ///   
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var processor = new Processor();
            processor.Run();
        }
    }
}

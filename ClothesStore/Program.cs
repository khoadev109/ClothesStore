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
        ///  Extends to order by more rates: discount rate,... instead of buying rate and selling rate
        ///  - Purpose:
        ///     + To prevent update concurrency quantity of clothes on specific record, but increase redundant data
        ///     + Can add more rate type without breaking current system
        ///  - Description:
        ///     + Current is:
        ///         * When buying clothes from supplier, add to stock with rate type is: Input
        ///         * When selling clothes to customer, add to stock with rate type is: Output
        ///     + When customer selling clothes:
        ///         * The inventory will be: currentInputQuantity - (currentOutputQuantity + quantityInputOfCustomer) >= 0
        ///     + When add new type of rate like: discount rate
        ///         * Order will base on this rate calculate and subtract discount price out of order's total price for customer
        ///         * The inventory will be: currentInputQuantity - (currentOutputQuantity + quantityInputOfCustomer + discountQuantity) >= 0
        ///         
        ///  Extends to order by more quantities: no charge quantity,... instead of buying quantity and selling quantity
        ///  - Purpose:
        ///     + Can add more quantity type without breaking current system
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var processor = new Processor();
            processor.Run();
        }
    }
}

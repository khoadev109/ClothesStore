using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Provider
{
    public class TransactionProvider
    {
        public static void ExecuteOperationInTransaction(Action executingAction)
        {
            try
            {
                executingAction();
            }
            catch (Exception ex)
            {
                Console.WriteLine("+ FAILED when execute in transaction.");
                throw ex;
            }
        }
    }
}

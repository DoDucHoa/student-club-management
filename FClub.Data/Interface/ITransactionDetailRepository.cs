using FClub.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Data.Interface
{
    interface ITransactionDetailRepository : IRepository<TransactionDetail>
    {
        void Update(TransactionDetail transactionDetail);
    }
}

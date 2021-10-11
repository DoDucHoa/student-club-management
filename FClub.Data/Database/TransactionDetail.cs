using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class TransactionDetail
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public decimal? TransPoint { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}

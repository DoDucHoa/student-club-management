using System;
using System.Collections.Generic;

#nullable disable

namespace FClub.Data.Database
{
    public partial class Wallet
    {
        public Wallet()
        {
            TransactionDetails = new HashSet<TransactionDetail>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public decimal? Point { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}

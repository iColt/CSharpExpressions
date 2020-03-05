using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExpressions.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string Code { get; set; }

        public string Notes { get; set; }

        public int? CustomerId { get; set; }

        public decimal NetAmount { get; set; }

        public bool Accepted { get; set; }

        public Order()
        {

        }

        #region Factory

        public Order GetOrder(int id)
        {
            return null;
        }

        #endregion
    }
}

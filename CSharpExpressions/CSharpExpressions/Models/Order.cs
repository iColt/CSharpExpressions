using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExpressions.Models
{

    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Id(x => x.OrderId, map => map.Generator(Generators.Native));
            Property(x => x.Code);
            Property(x => x.Notes);
            Property(x => x.CustomerId);
            Property(x => x.NetAmount);
            Property(x => x.Accepted);
        }
    }

    public class Order
    {
        public virtual int OrderId { get; set; }

        public virtual string Code { get; set; }

        public virtual string Notes { get; set; }

        public virtual int? CustomerId { get; set; }

        public virtual decimal NetAmount { get; set; }

        public virtual bool Accepted { get; set; }

        public Order()
        {

        }

        #region Factory

        //public Order GetOrder(int id)
        //{
        //    return null;
        //}

        #endregion
    }
}

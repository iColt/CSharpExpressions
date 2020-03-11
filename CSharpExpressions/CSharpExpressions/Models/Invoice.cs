using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Text;

namespace CSharpExpressions.Models
{

    public class InvoiceMap : ClassMapping<Invoice>
    {
        public InvoiceMap()
        {
            Id(x => x.InvoiceId, map => map.Generator(Generators.Native));
            Property(x => x.Code);
            Property(x => x.Notes);
            Property(x => x.CustomerId);
            Property(x => x.NetAmount);
            Property(x => x.Accepted);
            Property(x => x.AccountingNumberId);
        }
    }

    public class InvoiceBuilder
    {
        private int lastInvoiceCode;
        private int? customerId;
        private int? accountingNumberId;
        private Func<double> amountProvider;
        private StringBuilder futureNotes;

        public InvoiceBuilder(int lastInvoiceCode, int? customerId, int? accountingNumberId)
        {
            this.lastInvoiceCode = lastInvoiceCode;
            this.lastInvoiceCode++;
            this.customerId = customerId;
            this.accountingNumberId = accountingNumberId;

            futureNotes = new StringBuilder();
        }

        /// TODO: notes could be added to sb, then create string from sb before construct
        public InvoiceBuilder AddNotes(string notes)
        {
            futureNotes.Append(notes);
            return this;
        }

        public InvoiceBuilder AddAmountProvider(Func<double> call)
        {
            amountProvider = call;
            return this;
        }

        public Invoice Construct()
        {
            var newCode = "INV" + lastInvoiceCode;
            lastInvoiceCode++;
            return new Invoice() { Code = newCode,
                Notes = futureNotes.ToString(),
                CustomerId = customerId,
                Accepted = true,
                // TODO: review
                NetAmount = (decimal)amountProvider(),
                AccountingNumberId = accountingNumberId};
        }
    }

    public class Invoice
    {
        public virtual int InvoiceId { get; set; }

        public virtual string Code { get; set; }

        public virtual string Notes { get; set; }

        public virtual int? CustomerId { get; set; }

        public virtual decimal NetAmount { get; set; }

        public virtual bool Accepted { get; set; }

        public virtual int? AccountingNumberId { get; set;}
    }
}

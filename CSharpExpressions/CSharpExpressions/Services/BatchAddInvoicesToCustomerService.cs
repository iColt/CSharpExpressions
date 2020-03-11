using CSharpExpressions.Models;
using NHibernate;
using System;

namespace CSharpExpressions.Services
{
    public class BatchAddInvoicesToCustomerService
    {
        private int lastInvoiceCodeNum;

        public BatchAddInvoicesToCustomerService()
        {

        }

        public BatchAddInvoicesToCustomerService(int lastInvoiceCodeNum)
        {
            this.lastInvoiceCodeNum = lastInvoiceCodeNum;
        }

        public void AddInvoicesToCustomer(int customerId, int numOfInvoices, ISession session)
        {
            var rand = new Random();
            var builder = new InvoiceBuilder(1, 1, 1).AddAmountProvider(() => rand.NextDouble() * 100);
            using(ITransaction transaction = session.BeginTransaction())
            {
                for(int i = 0; i < numOfInvoices; i++)
                {
                    var obj = builder.Construct();
                    session.SaveOrUpdate(obj);

                }
                transaction.Commit();
            }
        }
    }
}

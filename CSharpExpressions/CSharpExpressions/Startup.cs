using CSharpExpressions.DataAccess;
using CSharpExpressions.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpExpressions
{
    public static class Startup
    {
        public static void Start()
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                var batchService = new BatchAddInvoicesToCustomerService(1);
                batchService.AddInvoicesToCustomer(1, 1000, session);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Stock.Model;

namespace Stock.Operation.CustomerServices
{
    public interface IManagementCustomerService
    {
        public Customer AddCustomer(Customer data);
        public List<Customer> ListCustomer();
    }
}

using IT_YARD.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IT_YARD.Interfaces
{
    interface ICustomerService
    {       
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Services.Models.Customer> GetAllCustomersWithProducts();
        bool AddNewCustomer(Customer item);
        Customer GetCustomer(Guid id);
        Services.Models.Customer GetCustomerWithProducts(Guid id);
        bool Update(Customer customer);
        bool Remove(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCompany.Data.Entity;

namespace MyCompany.Business.Repository
{
    public class CustomerRepository
    {
        IRepository<Customer> _conceretRepo; 
        public CustomerRepository(IRepository<Customer> concreteRepo)
        {
            _conceretRepo = concreteRepo;
 
        }

        public Customer FindCustomerById(string CustomerId)
        {
            return _conceretRepo.Find(p => p.CustomerID == CustomerId).FirstOrDefault();
        }

        public int InsertCustomer(Customer customer)
        {
             _conceretRepo.Add(customer);
             return 0;
           //  return _conceretRepo.Save();

        }
    }
}

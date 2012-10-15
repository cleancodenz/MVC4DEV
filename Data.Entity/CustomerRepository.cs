﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data.Entity
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
             return _conceretRepo.Save();

        }
    }
}

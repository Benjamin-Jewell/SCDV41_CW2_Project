using SCDV41_CW2_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCDV41_CW2_Project.Services
{
    internal class CustomerManager
    {
        //internal list to store customers
        private List<Customer> _customers = new();

        //method to add customer to list
        public void CreateCustomer(Customer newCustomer)
        {
            _customers.Add(newCustomer);
        }

        //method to output all customers in list
        public void ViewAllCustomers()
        {
            //check to see if there are any customers at all
            if (_customers.Count == 0)
            {
                Console.WriteLine("There are currently no customers stored, please create a customer");
            }
            else
            {
                Console.WriteLine("########################################################");
                Console.WriteLine("All customers:");
                Console.WriteLine("########################################################\n");
                foreach (var customer in _customers)
                {
                    customer.CustomerInfo();
                }
            }
        }
    }
}

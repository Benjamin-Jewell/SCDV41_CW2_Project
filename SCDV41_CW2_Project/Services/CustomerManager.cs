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

        //method to output all customers of a specific name in the list
        public void ViewCustomersByName(string name)
        {
            //search for the customer with the correct name
            //return that to a list
            var search = _customers.Where(w => w.Name.Equals(name)).ToList();

            if (search.Count == 0)
            {
                Console.WriteLine($"There are no customers with the name: {name} in the system.");
            }
            else
            {
                //loop through what has been returned and output a summary for each one
                foreach (var customer in search)
                {
                    customer.CustomerInfo();
                }
            }
        }
    }
}

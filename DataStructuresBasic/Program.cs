using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Assignment: DataStructuresBasic
 * Author: Klynt Yardley
 * Date: 9/20/2016
 * Description: Simulates a Hamburgar restaurant serving 100 customers.  The Program first populations a queue of 100 customers.  
 * As a customer orders the program records the number of hamburgers ordered in a dictionary. At the end of the program, each 
 * customer's name is printed with the number of hamburgers they have ordered.
 * 
*/

namespace DataStructuresBasic
{
    class Program
    {
        public static Random random = new Random();

        public static string randomName()
        {
            string[] names = new string[9] { "Dan Morain", "Emily Bell", "Klynt Yardley", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 8);
            return names[randomIndex];
        }

        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }


        static void Main(string[] args)
        {
            //Initiate the Queue, Dictionary, and List used by the program
            Queue<string> qsCustomers = new Queue<string>();
            Dictionary<string, int> dictOrders = new Dictionary<string, int>();
            List<string> lsAllCustomers = new List<string>();

            // Populates 100 customers in the queue
            for (int i = 1; i <= 100; i++)
            {
                qsCustomers.Enqueue(randomName());
            }

            // Simulates each customer coming through the line and ordering 
            for (int i = 1; i <= 100; i++)
            {
                String sCurrentCustomer = qsCustomers.Dequeue(); // Current Customer that we are serving
                
                if (!dictOrders.ContainsKey(sCurrentCustomer)) //Adds them to the dictionary if they are not already there
                {
                    const int iNewCustomer = 0; // Constant to begin each new customer with 0 Hamburgers
                    dictOrders.Add(sCurrentCustomer, iNewCustomer);
                    
                    dictOrders[sCurrentCustomer] = randomNumberInRange(); // Adds new order to the total in the dictionary
                    
                    lsAllCustomers.Add(sCurrentCustomer); //Adds new customer to the list of all customers
                }

                else //If they are not a new customer, program simply adds the new order the the total in the Dictionary
                {
                    dictOrders[sCurrentCustomer] += randomNumberInRange();
                }
            }
            

            //Prints Customer Summary
            foreach(string customer in lsAllCustomers)
            {
                Console.WriteLine(customer + "\t\t" + dictOrders[customer]);
            }

            Console.ReadKey();
        }
    }
}

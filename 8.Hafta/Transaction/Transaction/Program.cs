using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
 
        public class Transaction
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
            public string Address { get; set; }
            public List<Reservation> Reservations { get; set; } = new List<Reservation>();

            public void Update()
            {
                Console.WriteLine($"Transaction {Id} updated");
            }
        }

        public class Reservation
        {
            public int Id { get; set; }
            public string Details { get; set; }
            public string List { get; set; }
            public RentingOwner RentingOwner { get; set; }

            public void Confirmation()
            {
                Console.WriteLine($"Reservation {Id} confirmed");
            }
        }

        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Contact { get; set; }
            public string Address { get; set; }
            public int Payment { get; set; }
            public List<Transaction> Transactions { get; set; } = new List<Transaction>();
            public List<Payment> Payments { get; set; } = new List<Payment>();

            public void Update()
            {
                Console.WriteLine($"Customer {Name} updated");
            }
        }

        public class Car
        {
            public int Id { get; set; }
            public int Details { get; set; }
            public string OrderType { get; set; }
            public RentingOwner Owner { get; set; }

            public void ProcessDebit()
            {
                Console.WriteLine($"Processing debit for car {Id}");
            }
        }

        public class RentingOwner
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }
            public string ContactNum { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public List<Rentals> Rentals { get; set; } = new List<Rentals>();

            public bool VerifyAccount()
            {
                Console.WriteLine($"Verifying account for {Name}");
                return true;
            }
        }

        public class Payment
        {
            public int Id { get; set; }
            public int CardNumber { get; set; }
            public string Amount { get; set; }

            public void Add()
            {
                Console.WriteLine($"Payment {Id} added");
            }

            public void Update()
            {
                Console.WriteLine($"Payment {Id} updated");
            }
        }

        public class Rentals
        {
            public int Id { get; set; }
            public string Names { get; set; }
            public string Price { get; set; }
            public List<Payment> Payments { get; set; } = new List<Payment>();

            public void Add()
            {
                Console.WriteLine($"Rental {Id} added");
            }

            public void Update()
            {
                Console.WriteLine($"Rental {Id} updated");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Create a renting owner
                var owner = new RentingOwner
                {
                    Id = 1,
                    Name = "John Doe",
                    Age = "35",
                    ContactNum = "555-0123",
                    Username = "johndoe",
                    Password = "password123"
                };

                // Create a car
                var car = new Car
                {
                    Id = 1,
                    Details = 2023,
                    OrderType = "Rental",
                    Owner = owner
                };

                // Create a customer
                var customer = new Customer
                {
                    Id = 1,
                    Name = "Jane Smith",
                    Contact = "555-4567",
                    Address = "123 Main St",
                    Payment = 0
                };

                // Create a payment
                var payment = new Payment
                {
                    Id = 1,
                    CardNumber = 123456789,
                    Amount = "500.00"
                };

                // Create a rental
                var rental = new Rentals
                {
                    Id = 1,
                    Names = "Weekend Rental",
                    Price = "500.00"
                };
                rental.Payments.Add(payment);
                owner.Rentals.Add(rental);

                // Create a transaction
                var transaction = new Transaction
                {
                    Id = 1,
                    Name = "Car Rental Transaction",
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    Address = "123 Main St"
                };
                customer.Transactions.Add(transaction);

                // Create a reservation
                var reservation = new Reservation
                {
                    Id = 1,
                    Details = "Weekend car rental",
                    List = "Active",
                    RentingOwner = owner
                };
                transaction.Reservations.Add(reservation);

                // Demonstrate some operations
                Console.WriteLine("--- System Demo ---");
                owner.VerifyAccount();
                car.ProcessDebit();
                payment.Add();
                rental.Add();
                reservation.Confirmation();
                transaction.Update();
                customer.Update();

                // Display some information
                Console.WriteLine("\n--- Rental Information ---");
                Console.WriteLine($"Customer: {customer.Name}");
                Console.WriteLine($"Car Owner: {owner.Name}");
                Console.WriteLine($"Rental Price: ${rental.Price}");
                Console.WriteLine($"Transaction Date: {transaction.Date}");
                Console.WriteLine($"Reservation Details: {reservation.Details}");

                Console.ReadLine(); // Program sonunda beklemek için
            }
        }
    }
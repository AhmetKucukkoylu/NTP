using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Otomasyon
{
    // Abstract Product Class
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public abstract void DisplayInfo();
    }

    // Concrete Product Classes
    public class FoodProduct : Product
    {
        public DateTime ExpirationDate { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Gıda Ürünü: {Name}, Fiyat: {Price:C}, Son Kullanma: {ExpirationDate.ToShortDateString()}");
        }
    }

    public class ElectronicProduct : Product
    {
        public string WarrantyPeriod { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Elektronik Ürün: {Name}, Fiyat: {Price:C}, Garanti: {WarrantyPeriod}");
        }
    }

    // Abstract Customer Class
    public abstract class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }

        public abstract decimal CalculateDiscount(decimal totalAmount);
    }

    // Concrete Customer Classes
    public class IndividualCustomer : Customer
    {
        public string TcNo { get; set; }

        public override decimal CalculateDiscount(decimal totalAmount)
        {
            return totalAmount >= 1000 ? totalAmount * 0.1m : 0;
        }
    }

    public class CorporateCustomer : Customer
    {
        public string TaxNumber { get; set; }
        public string CompanyName { get; set; }

        public override decimal CalculateDiscount(decimal totalAmount)
        {
            return totalAmount >= 5000 ? totalAmount * 0.15m : totalAmount * 0.05m;
        }
    }

    // Abstract Payment Class
    public abstract class Payment
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public abstract bool ProcessPayment();
    }

    // Concrete Payment Classes
    public class CreditCardPayment : Payment
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }

        public override bool ProcessPayment()
        {
            try
            {
                Console.WriteLine($"Kredi kartı ile {Amount:C} ödeme işlemi gerçekleştiriliyor...");
                // Kredi kartı işlem simülasyonu
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ödeme hatası: {ex.Message}");
                return false;
            }
        }
    }

    public class CashPayment : Payment
    {
        public decimal ReceivedAmount { get; set; }

        public override bool ProcessPayment()
        {
            try
            {
                Console.WriteLine($"Nakit ödeme: {Amount:C}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ödeme hatası: {ex.Message}");
                return false;
            }
        }
    }

    // Cart Class
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalAmount => CalculateTotal();

        private decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Product.Price * item.Quantity;
            }
            return total;
        }

        public void AddItem(Product product, int quantity)
        {
            try
            {
                if (product.Stock < quantity)
                    throw new Exception("Yetersiz stok!");

                var existingItem = Items.Find(i => i.Product.Id == product.Id);
                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    Items.Add(new CartItem { Product = product, Quantity = quantity });
                }
                product.Stock -= quantity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    // Order Class
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public Cart Cart { get; set; }
        public Payment Payment { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }

        public void ProcessOrder()
        {
            try
            {
                if (Payment.ProcessPayment())
                {
                    Status = OrderStatus.Confirmed;
                    Console.WriteLine("Sipariş onaylandı ve işleme alındı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sipariş işleme hatası: {ex.Message}");
                Status = OrderStatus.Failed;
            }
        }
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Preparing,
        Delivered,
        Failed
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Ürünleri oluştur
                var apple = new FoodProduct
                {
                    Id = 1,
                    Name = "Elma",
                    Price = 10.99m,
                    Stock = 100,
                    ExpirationDate = DateTime.Now.AddDays(10)
                };

                var laptop = new ElectronicProduct
                {
                    Id = 2,
                    Name = "Laptop",
                    Price = 15000m,
                    Stock = 10,
                    WarrantyPeriod = "2 Yıl"
                };

                // Müşteri oluştur
                var customer = new CorporateCustomer
                {
                    Id = 1,
                    Name = "ABC Şirketi",
                    CompanyName = "ABC Ltd.",
                    TaxNumber = "1234567890"
                };

                // Sepet oluştur
                var cart = new Cart();
                cart.AddItem(apple, 5);
                cart.AddItem(laptop, 1);

                // Ödeme oluştur
                var payment = new CreditCardPayment
                {
                    Amount = cart.TotalAmount,
                    PaymentDate = DateTime.Now,
                    CardNumber = "1234-5678-9012-3456",
                    CardHolderName = "John Doe"
                };

                // Sipariş oluştur
                var order = new Order
                {
                    OrderId = 1,
                    Customer = customer,
                    Cart = cart,
                    Payment = payment,
                    Status = OrderStatus.Pending,
                    OrderDate = DateTime.Now
                };

                // Siparişi işle
                order.ProcessOrder();

                // Sipariş detaylarını göster
                Console.WriteLine("\nSipariş Detayları:");
                Console.WriteLine($"Sipariş No: {order.OrderId}");
                Console.WriteLine($"Müşteri: {order.Customer.Name}");
                Console.WriteLine($"Toplam Tutar: {cart.TotalAmount:C}");
                Console.WriteLine($"Durum: {order.Status}");

                Console.WriteLine("\nSepetteki Ürünler:");
                foreach (var item in cart.Items)
                {
                    item.Product.DisplayInfo();
                    Console.WriteLine($"Miktar: {item.Quantity}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sistem Hatası: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}

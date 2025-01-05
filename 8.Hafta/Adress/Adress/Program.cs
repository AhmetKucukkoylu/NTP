using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adress
{
    class Program
    {
        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int PostalCode { get; set; }
            public string Country { get; set; }

            public bool Validate()
            {
                return !string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(City);
            }

            public string OutputAsLabel()
            {
                return $"{Street}, {City}, {State}, {PostalCode}, {Country}";
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailAddress { get; set; }
            public Address LivesAt { get; set; }  // 0..1 ilişkiyi temsil ediyor

            public void PurchaseParkingPass()
            {
                Console.WriteLine($"{Name} has purchased a parking pass.");
            }
        }

        public class Student : Person
        {
            public int StudentNumber { get; set; }
            public int AverageMark { get; set; }

            public bool IsEligibleToEnroll()
            {
                return AverageMark >= 50; // Ortalama notu 50 ve üzeriyse kayıt olabilir
            }

            public int GetSeminarsTaken()
            {
                return new Random().Next(1, 10); // Rastgele bir seminer sayısı döndürür
            }
        }

        public class Professor : Person
        {
            public int Salary { get; set; }
            public int StaffNumber { get; set; }
            public int YearsOfService { get; set; }
            public int NumberOfClasses { get; set; }

            public List<Student> SupervisedStudents { get; set; } = new List<Student>(); // 1..5 arası ilişki

            public void SuperviseStudent(Student student)
            {
                if (SupervisedStudents.Count < 5)
                {
                    SupervisedStudents.Add(student);
                    Console.WriteLine($"{Name} is now supervising {student.Name}.");
                }
                else
                {
                    Console.WriteLine($"{Name} cannot supervise more than 5 students.");
                }
            }
        }

        // ✅ `Program` sınıfı içinde `Program` adlı bir metot veya değişken yok
        class Program
        {
            static void Main()
            {
                // Adres nesnesi oluşturuluyor
                Address address = new Address
                {
                    Street = "123 Main St",
                    City = "Istanbul",
                    State = "TR",
                    PostalCode = 34000,
                    Country = "Turkey"
                };

                // Öğrenci nesneleri oluşturuluyor
                Student student1 = new Student
                {
                    Name = "Ali",
                    PhoneNumber = "555-1234",
                    EmailAddress = "ali@example.com",
                    LivesAt = address,
                    StudentNumber = 1001,
                    AverageMark = 75
                };

                Student student2 = new Student
                {
                    Name = "Ayşe",
                    PhoneNumber = "555-5678",
                    EmailAddress = "ayse@example.com",
                    LivesAt = address,
                    StudentNumber = 1002,
                    AverageMark = 85
                };

                // Profesör nesnesi oluşturuluyor
                Professor professor = new Professor
                {
                    Name = "Dr. Ahmet",
                    PhoneNumber = "555-8765",
                    EmailAddress = "ahmet@example.com",
                    LivesAt = address,
                    Salary = 50000,
                    StaffNumber = 2001,
                    YearsOfService = 10,
                    NumberOfClasses = 3
                };

                // Profesör, öğrencileri denetlemeye başlıyor
                professor.SuperviseStudent(student1);
                professor.SuperviseStudent(student2);

                // Öğrencilerin kayıt uygunluğu kontrol ediliyor
                Console.WriteLine($"{student1.Name} is eligible to enroll: {student1.IsEligibleToEnroll()}");
                Console.WriteLine($"{student2.Name} is eligible to enroll: {student2.IsEligibleToEnroll()}");

                // Öğrenci kaç seminer aldı?
                Console.WriteLine($"{student1.Name} has taken {student1.GetSeminarsTaken()} seminars.");
                Console.WriteLine($"{student2.Name} has taken {student2.GetSeminarsTaken()} seminars.");

                // Adres doğrulaması
                Console.WriteLine($"Is {address.OutputAsLabel()} a valid address? {address.Validate()}");

                // Otopark kartı satın alma
                student1.PurchaseParkingPass();
                professor.PurchaseParkingPass();
                Console.Read();
            }
        }
    }
}
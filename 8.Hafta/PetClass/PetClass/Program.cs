using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClass
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }

    public interface IExperienced
    {
        // Interface for Owner's experience requirements
    }

    public class Owner : IExperienced
    {
        public string Name { get; set; }

        public Owner(string name)
        {
            Name = name;
        }
    }

    public class Animal
    {
        public string Type { get; set; }
        public string Breed { get; set; }
        public bool Carnivore { get; set; }
    }

    public class Vaccine
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Vaccine(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public class PetInformation
    {
        public List<string> Traits { get; set; }
        public List<Vaccine> Vaccines { get; set; }

        public PetInformation()
        {
            Traits = new List<string>();
            Vaccines = new List<Vaccine>();
        }
    }

    public class Pet : Animal, IIdentifiable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public Owner Owner { get; set; }
        public PetInformation PetInfo { get; set; }

        public Pet(string name, int age, Owner owner, string type, string breed, bool carnivore)
        {
            Name = name;
            Age = age;
            Owner = owner;
            Type = type;
            Breed = breed;
            Carnivore = carnivore;
            PetInfo = new PetInformation();
        }

        public bool Feed()
        {
            Console.WriteLine($"{Name} has been fed!");
            return true;
        }

        public bool IsHerbivore()
        {
            return !Carnivore;
        }
   

    class Program
    {
        public static void Main(string[] args)
        {
            // Örnek kullanım
            Owner owner1 = new Owner("John Doe");

            Pet pet1 = new Pet(
                name: "Buddy",
                age: 3,
                owner: owner1,
                type: "Dog",
                breed: "Golden Retriever",
                carnivore: true
            );

            // Pet bilgilerini düzenle
            pet1.PetInfo.Traits.Add("Friendly");
            pet1.PetInfo.Traits.Add("Active");
            pet1.PetInfo.Vaccines.Add(new Vaccine("Rabies", "Annual"));
            pet1.PetInfo.Vaccines.Add(new Vaccine("Distemper", "Core"));

            // Bilgileri göster
            Console.WriteLine($"Pet ID: {pet1.Id}");
            Console.WriteLine($"Pet Name: {pet1.Name}");
            Console.WriteLine($"Pet Age: {pet1.Age}");
            Console.WriteLine($"Owner: {pet1.Owner.Name}");
            Console.WriteLine($"Type: {pet1.Type}");
            Console.WriteLine($"Breed: {pet1.Breed}");
            Console.WriteLine($"Is Herbivore: {pet1.IsHerbivore()}");

            Console.WriteLine("\nTraits:");
            foreach (var trait in pet1.PetInfo.Traits)
            {
                Console.WriteLine($"- {trait}");
            }

            Console.WriteLine("\nVaccines:");
            foreach (var vaccine in pet1.PetInfo.Vaccines)
            {
                Console.WriteLine($"- {vaccine.Name} ({vaccine.Type})");
            }

            // Feed the pet
            pet1.Feed();
        }
    }
}
}

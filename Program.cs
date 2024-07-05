using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCRUDApp
{
    class Program
    {
        static List<Person> people = new List<Person>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Create a new person");
                Console.WriteLine("2. Read all people");
                Console.WriteLine("3. Update a person");
                Console.WriteLine("4. Delete a person");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreatePerson();
                        break;
                    case "2":
                        ReadPeople();
                        break;
                    case "3":
                        UpdatePerson();
                        break;
                    case "4":
                        DeletePerson();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void CreatePerson()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();
            Console.Write("Enter age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                var person = new Person { Id = nextId++, Name = name, Age = age };
                people.Add(person);
                Console.WriteLine("Person added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid age.");
            }
        }

        static void ReadPeople()
        {
            if (people.Any())
            {
                Console.WriteLine("\nList of people:");
                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            else
            {
                Console.WriteLine("No people found.");
            }
        }

        static void UpdatePerson()
        {
            Console.Write("Enter the ID of the person to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var person = people.FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    Console.Write("Enter new name: ");
                    person.Name = Console.ReadLine();
                    Console.Write("Enter new age: ");
                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        person.Age = age;
                        Console.WriteLine("Person updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid age.");
                    }
                }
                else
                {
                    Console.WriteLine("Person not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        static void DeletePerson()
        {
            Console.Write("Enter the ID of the person to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var person = people.FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    people.Remove(person);
                    Console.WriteLine("Person deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Person not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
    }
}

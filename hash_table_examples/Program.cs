using System;
using System.Collections;
using System.Collections.Generic;

namespace hash_table_examples
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Hashtable phoneBookTest = new Hashtable();
            //Create a new instance of hashtable
            Hashtable phoneBook = new Hashtable()
            {
                { "Damilola Afolabi", "08127609067" },
                { "David Ogunleye", "08121200853" },
                { "Inyang Naomi", "08135171248" }
            };
            phoneBook["Ayommide Fagoroye"] = "08111851538"; // using indexer
            phoneBook["Ene Ebube"] = "08159962308";

            try
            {
                phoneBook.Add("Bolu Omotoro", "08077329962");
                phoneBook.Add("Nmesoma Ngozi", "09032200986");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists.");
            }

            //remove a contact
            phoneBook.Remove("Ayommide Fagoroye");

            //print out all phonenumbers
            Console.WriteLine("Phone numbers:");
            if (phoneBook.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (DictionaryEntry entry in phoneBook)
                {
                    Console.WriteLine($" - {entry.Key}: {entry.Value}");
                }
            }

            // search phonebook by name
            Console.WriteLine();
            Console.Write("Search by name: ");
            string name = Console.ReadLine();
            if (phoneBook.Contains(name)) //extend this line to also search by value
            {
                string number = (string)phoneBook[name];
                Console.WriteLine($"Found phone number: {number}");
            }
            else
            {
                Console.WriteLine("The entry does not exist.");
            }


            /////////////DICTIONARY//////////////////////////
            Dictionary<long, string> products =
                new Dictionary<long, string>
            {
                { 5900000000000, "A1" },
                { 5901111111111, "B5" },
                { 5902222222222, "C9" }
            };
            products[5903333333333] = "D7";
            try
            {
                products.Add(5904444444444, "A3");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists.");
            }

            //print all products
            Console.WriteLine("All products:");
            if (products.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (KeyValuePair<long, string> product in products)
                {
                    Console.WriteLine($" - {product.Key}: {product.Value}");
                }
            }

            Console.WriteLine();
            Console.Write("Search by barcode: ");
            long barcode = long.Parse(Console.ReadLine());
            if (products.TryGetValue(barcode, out string location))
            {
                Console.WriteLine($"The product is in the area {location}.");
            }
            else
            {
                Console.WriteLine("The product does not exist.");
            }



            /////////////USER DETAILS///////////////////////////
            Dictionary<int, Employee> employees =
            new Dictionary<int, Employee>
            {
                {
                    100,
                    new Employee()
                    {
                        FirstName = "Bolu",
                        LastName = "Omotoro",
                        PhoneNumber = "08077329962"
                    }
                },
                {
                    200,
                    new Employee()
                    {
                        FirstName = "Damilola",
                        LastName = "Afolabi",
                        PhoneNumber = "08127609067"
                    }
                },
                {
                    300,
                    new Employee()
                    {
                        FirstName = "Ayomide",
                        LastName = "Fagoroye",
                        PhoneNumber = "08111851538"
                    }
                }
            };

            bool isCorrect;
            do
            {
                Console.Write("Enter the employee identifier: ");
                string idString = Console.ReadLine();
                isCorrect = int.TryParse(idString, out int id);
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (employees.TryGetValue(id, out Employee employee))
                    {
                        Console.WriteLine("First name: {1}{0}Last name: {2}{0}Phone number: {3}",
                                Environment.NewLine,
                                employee.FirstName,
                                employee.LastName,
                                employee.PhoneNumber);
                    }
                    else
                    {
                        Console.WriteLine("The employee with the given identifier does not exist.");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            while (isCorrect);



            ////////////////SORTED DICTIONARY///////////////////////////
            SortedDictionary<string, string> encyclopedia =
            new SortedDictionary<string, string>();
            do
            {
                Console.Write("Choose an option ([a] - add, [l] - list): ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();
                if (keyInfo.Key == ConsoleKey.A)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter the name: ");
                    string word = Console.ReadLine();
                    Console.Write("Enter the explanation: ");
                    string explanation = Console.ReadLine();
                    encyclopedia[word] = explanation;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (keyInfo.Key == ConsoleKey.L)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach (KeyValuePair<string, string> definition
                        in encyclopedia)
                    {
                        Console.WriteLine($"{definition.Key}: { definition.Value}");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Do you want to exit the program? Press[y](yes) or[n](no).");

                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        break;
                    }
                }
            }
            while (true);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingListLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            Dictionary<string, double> items = new Dictionary<string, double>(comparer);
            items.Add("Pringles", 1.99);
            items.Add("IceBreaker Mints", 2.31);
            items.Add("Red Bull", 3.39);
            items.Add("Diet Pepsi", 2.50);
            items.Add("Salted Pistachios", 4.49);
            items.Add("Hot Cheeto Puffcorn", 2.00);
            items.Add("Crunch Chocolate Bar", 3.50);
            items.Add("Protein Bar", 3.00);
            items.Add("Salt and Vinegar Kettle Chips", 2.29);
            items.Add("Coffee", 1.50);

            foreach (KeyValuePair<string, double> kvp in items)
            {
                Console.WriteLine($"{kvp.Key,-35}$ {kvp.Value:0.00}");
            }

            List<string> shoppingListItems = new List<string>();
            List<double> prices = new List<double>();

            bool repeat = true;

            while (repeat)
            {
                Console.Write("\nWhat would you like? Enter an item from list: ");
                string input = Console.ReadLine();

                bool keyExists = items.ContainsKey(input);

                if (keyExists)
                {
                    foreach (KeyValuePair<string, double> kvp in items)
                    {
                        if (kvp.Key.ToLower() == input.ToLower())
                        {
                            Console.WriteLine($"\n{kvp.Key}............. $ {kvp.Value:0.00}");
                            shoppingListItems.Add(kvp.Key);
                            prices.Add(kvp.Value);
                        }
                    }

                    repeat = Repeat();
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                }
            }

            Console.WriteLine("\n\nHere is your receipt: ");
            for (int i = 0; i < shoppingListItems.Count; i++)
            {
                Console.WriteLine($"{shoppingListItems[i], -50}$ {prices[i]:0.00}");
            }

            Console.WriteLine($"{"\nTotal: "}....................................$ {prices.Sum():0.00}");
            Console.WriteLine($"{"The average price of your items is: "}.......$ {prices.Average():0.00}");
        }

        public static bool Repeat()
        {
            while (true)
            {
                Console.Write("\nWould you like to add another item? (y/n): ");
                string answer = Console.ReadLine();

                if (answer == "n")
                {
                    return false;
                }
                else if (answer == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                }
            }
        }
    }
}

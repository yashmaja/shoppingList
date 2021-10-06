using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingListLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Yash's Market!");

            List<string> shoppingListItems = new List<string>();
            List<double> prices = new List<double>();

            var comparer = StringComparer.OrdinalIgnoreCase;
            Dictionary<string, double> items = new Dictionary<string, double>(comparer);
            items.Add("A - Pringles", 1.99);
            items.Add("B - IceBreaker Mints", 2.31);
            items.Add("C - Red Bull", 3.39);
            items.Add("D - Diet Pepsi", 2.50);
            items.Add("E - Salted Pistachios", 4.49);
            items.Add("F - Hot Cheeto Puffcorn", 2.00);
            items.Add("G - Crunch Chocolate Bar", 3.50);
            items.Add("H - Protein Bar", 3.00);
            items.Add("I - Salt and Vinegar Kettle Chips", 2.29);
            items.Add("J - Coffee", 1.50);
            
            bool repeat = true;

            while (repeat)
            {
                PrintDictionary(items);
                
                string addItem = GetItemNum(items);
                shoppingListItems.Add(addItem.Substring(3));
                prices.Add(items[addItem]);
                
                repeat = Repeat();
            }

            PrintReceipt(shoppingListItems, prices);
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

        public static void PrintDictionary(Dictionary<string, double> dict)
        {
            Console.WriteLine($"{"Item",-35} Price");
            Console.WriteLine("================================================");
            foreach (KeyValuePair<string, double> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key,-35}$ {kvp.Value:0.00}");
            }
        }

        public static string GetItem(Dictionary<string, double> dict)
        {
            while(true)
            {
                Console.Write("\nWhat would you like? Enter an item from list: ");
                string input = Console.ReadLine();

                bool keyExists = dict.ContainsKey(input);
                if (keyExists)
                {
                    foreach (KeyValuePair<string, double> kvp in dict)
                    {
                        if (kvp.Key.ToLower() == input.ToLower())
                        {
                            Console.WriteLine($"\nAdding {kvp.Key}............. $ {kvp.Value:0.00}");
                            input = kvp.Key;

                        }
                    }
                    return input;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                }
            }
        }

        static void PrintReceipt(List<string> itemNames, List<double> itemPrices)
        {
            Console.WriteLine("\n\nHere is your receipt: ");
            for (int i = 0; i < itemNames.Count; i++)
            {
                Console.WriteLine($"{itemNames[i],-25}$ {itemPrices[i]:0.00}");
            }

            Console.WriteLine($"{"\nTotal: "}....................................$ {itemPrices.Sum():0.00}");
            Console.WriteLine($"{"The average price of your items is: "}.......$ {itemPrices.Average():0.00}");
        }

        static string GetItemNum(Dictionary<string, double> numDict)
        {
            bool validInput = true;

            while (true)
            {
                Console.Write("\nWhat would you like? Enter number of item (A-J): ");
                string input = Console.ReadLine();

                foreach (KeyValuePair<string, double> kvp in numDict)
                {
                    if (kvp.Key.ToUpper().Substring(0, 1) == input.ToUpper())
                    {
                        Console.WriteLine($"\nAdding {kvp.Key.Substring(3)}............. $ {kvp.Value:0.00}");
                        input = kvp.Key;
                        return input;
                        //break;
                    }
                    else
                    {
                        validInput = false;
                    }
                }
                
                if (validInput == false)
                {
                    Console.WriteLine("\nInvalid input. Try again.\n");
                }
            }
        }
    }
}

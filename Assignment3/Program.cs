using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;

namespace Assignment3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SLL sll = new SLL();

            // Test 1: Add users to the list
            Console.WriteLine("Test 1: Adding users to the list");
            sll.AddFirst(new User(1, "Alice", "alice@mail.com", "password123"));
            sll.AddFirst(new User(2, "Bob", "bob@mail.com", "password456"));
            sll.AddLast(new User(3, "Charlie", "charlie@mail.com", "password789"));
            sll.AddLast(new User(4, "Diana", "diana@mail.com", "password000"));

            Console.WriteLine("Users added to the list.");

            // Test 2: Display the users in the list
            Console.WriteLine("\nTest 2: Displaying users in the list");
            for (int i = 0; i < sll.Count(); i++)
            {
                Console.WriteLine($"User {i + 1}: {sll.GetValue(i).Name}");
            }

            // Test 3: Remove the first user
            Console.WriteLine("\nTest 3: Removing the first user");
            sll.RemoveFirst();
            Console.WriteLine("First user removed.");
            for (int i = 0; i < sll.Count(); i++)
            {
                Console.WriteLine($"User {i + 1}: {sll.GetValue(i).Name}");
            }

            // Test 4: Remove the last user
            Console.WriteLine("\nTest 4: Removing the last user");
            sll.RemoveLast();
            Console.WriteLine("Last user removed.");
            for (int i = 0; i < sll.Count(); i++)
            {
                Console.WriteLine($"User {i + 1}: {sll.GetValue(i).Name}");
            }

            // Test 5: Add a new user at the beginning
            Console.WriteLine("\nTest 5: Adding a new user at the beginning");
            sll.AddFirst(new User(5, "Eve", "eve@mail.com", "password111"));
            Console.WriteLine("New user added at the beginning.");
            for (int i = 0; i < sll.Count(); i++)
            {
                Console.WriteLine($"User {i + 1}: {sll.GetValue(i).Name}");
            }

            // Test 6: Replace the user at index 1 (second user)
            Console.WriteLine("\nTest 6: Replacing the user at index 1");
            sll.Replace(new User(6, "Frank", "frank@mail.com", "password222"), 1);
            Console.WriteLine("User at index 1 replaced.");
            for (int i = 0; i < sll.Count(); i++)
            {
                Console.WriteLine($"User {i + 1}: {sll.GetValue(i).Name}");
            }

            // Test 7: Check if a user exists
            Console.WriteLine("\nTest 7: Checking if a user exists in the list");
            Console.WriteLine(sll.Contains(new User(3, "Charlie", "charlie@mail.com", "password789")) ? "Charlie is in the list." : "Charlie is not in the list.");

            // Test 8: Get user by index
            Console.WriteLine("\nTest 8: Getting a user by index");
            try
            {
                User userAtIndex = sll.GetValue(1);
                Console.WriteLine($"User at index 1: {userAtIndex.Name}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            // Test 9: Check if the list is empty
            Console.WriteLine("\nTest 9: Checking if the list is empty");
            Console.WriteLine(sll.IsEmpty() ? "The list is empty." : "The list is not empty.");

            // Test 10: Clear the list
            Console.WriteLine("\nTest 10: Clearing the list");
            sll.Clear();
            Console.WriteLine(sll.IsEmpty() ? "The list is empty after clearing." : "The list is not empty after clearing.");
        }


    }
}

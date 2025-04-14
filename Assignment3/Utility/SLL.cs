using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class SLL : ILinkedListADT
    {
        public Node Head { get; set; }
        public Node  Tail { get; set; }
        public int Counter { get; set; }

        public SLL()
        {
            Head = null;
            Tail = null;
            Counter = 0;
        }

        public void PrintAllNodes()
        {
            Node current = Head;
            if (current == null)
            {
                Console.WriteLine("Sorry, nothing is in there!");
                return;
            }

            while (current != null)
            {
                User user = current.Data;
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Password: {user.Password}");
                current = current.Next;
            }
        }


        /// <summary>
        /// Adds a new element at a specific position.
        /// </summary>
        /// <param name="value">Value that element is to contain.</param>
        /// <param name="index">Index to add new element at.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
        public void Add(User value, int index)
        {
            //New node
            Node node = new Node(value);

            if(IsEmpty())
            {
                Head = node;
                Tail = node;
                Counter++;

            }

            //If the index is out of range
            if (index < 0 || index > Counter)
            {
                //Throw an exception
                throw new IndexOutOfRangeException("Index out of range");
            }

            //If the index is not out of range
            else
            {
                //If the index is the head
                if (index == 0)
                {
                    //Add the new node at the beginning
                    AddFirst(value);
                }
                //If the index is the tail 
                else if (index == Counter - 1)
                {
                    //Add the new node at the end
                    AddLast(value);
                }

                //If the index is in the middle
                else
                {
                    //New node that points to the head
                    Node current = Head;

                    //cuurentindex set to 0, so Head[0]
                    int currentIndex = 0;

                    //While the current node is not the one before the index selected
                    while (currentIndex < index - 1)
                    {
                        //Move to the next node
                        current = current.Next;
                        //Increment the index counter
                        currentIndex++;
                    }

                    //Add the new node at the correct index (next to the current node)
                    node.Next = current.Next;
                    current.Next = node;

                    
                }
                //Increment the count
                Counter++;
            }
        }

        /// <summary>
        /// Prepends (adds to beginning) value to the list.
        /// </summary>
        /// <param name="value">Value to store inside element.</param>
        public void AddFirst(User value)
        {
            //New node 
            Node node = new Node(value);

            //If the list is empty
            if (IsEmpty())
            {
                //If i had just one data in the list it will be the head, tail and it will add one
                Head = node;
                Tail = node;
                
            }
            
            
            //If the list is not empty
            else
            {
                //Add the new node as the head
                node.Next = Head;
                Head = node;
            }
            //Increment the count
            Counter++;
        }

        /// <summary>
        /// Adds to the end of the list.
        /// </summary>
        /// <param name="value">Value to append.</param>
        public void AddLast(User value)
        {
            //New node 
            Node node = new Node(value);

            //If the list is empty
            if(IsEmpty())
            {
                // The list is empty
                Head = node;
                Tail = node;
                  
            }

            //If the list is not empty
            else
            {
                //Add the new node as the tail
                Tail.Next = node;
                //The new node is now the tail
                Tail = node;
            }
            //Increment the count
            Counter++;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            //The head and tail are set to null, counter is set to 0
            Head = null;
            Tail = null;
            Counter = 0;
        }

        /// <summary>
        /// Go through nodes and check if one has value.
        /// </summary>
        /// <param name="value">Value to find index of.</param>
        /// <returns>True if element exists with value.</returns>
        public bool Contains(User value)
        {
            //New node that points to the head
            Node current = Head;

            //While the current node is not null
            while (current != null)
            {
                //If the current node's data is equal to the value
                if (current.Data.Equals(value))
                {
                    return true; // Return true
                }
                current = current.Next; //If not equal, move to the next node
            }
            return false; //If the value is not in the list, return false
        }

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        /// <returns>Size of list (0 meaning empty)</returns>
        public int Count()
        {
            //New node that points to the head
            Node current = Head;

            //If the head is null
            if (IsEmpty())
            {
                // The list is empty
                return 0;
            }

            //Return the count
            return Counter;
        }

        /// <summary>
        /// Gets the value at the specified index.
        /// </summary>
        /// <param name="index">Index of element to get.</param>
        /// <returns>Value of node at index</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public User GetValue(int index)
        {

            // New node that points to the head
            Node current = Head;

            // If the list is empty
            if (IsEmpty())
            {
                Console.WriteLine("Sorry, the list is empty!");
                return null;
            }

            for (int indexNode = 0; indexNode < index; indexNode++)
            {
                current = current.Next;
            }

            // Return the value of the node at the given index
            return current.Data;

        }

        /// <summary>
        /// Gets the first index of element containing value.
        /// </summary>
        /// <param name="value">Value to find index of.</param>
        /// <returns>First of index of node with matching value or -1 if not found.</returns>
        public int IndexOf(User value)
        {
            //New node that points to the head
            Node current = Head;

            //If the head is null
            if (IsEmpty())
            {
                // The list is empty
                throw new Exception("List is empty.");
            }

            //Index of the value set to 0 in order to find it
            int index = 0;

            //While the current node is not null
            while (current != null)
            {
                //If the current node's data is equal to the value
                if (current.Data.Equals(value))
                {
                    return index; // Return the index.
                }

                //If not equal, move to the next node
                current = current.Next;
                //Increment the index
                index++;
            }

            //If the value is not in the list, return -1
            return -1;

        }

        /// <summary>
        /// Checks if the list is empty.
        /// </summary>
        /// <returns>True if it is empty.</returns>
        public bool IsEmpty()
        {
            //New node that points to the head
            Node current = Head;

            //If the head is null
            if (current == null)
            {
                //The list is empty
                return true;
            }
            //If the head is not null
            else
            {
                //The list is not empty
                return false;
            }
        }

        /// <summary>
        /// Removes element at index from list, reducing the size.
        /// </summary>
        /// <param name="index">Index of element to remove.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public void Remove(int index)
        {
            Node current = Head;

            if (IsEmpty())
            {
                // The list is empty
                Console.WriteLine("Sorry, the list is already empty!");
                return;
                
            }

            if (index < 0 || index >= Counter)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            else
            {
                for (int indexNode = 0; indexNode < index - 1; indexNode++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
        }

        /// <summary>
        /// Removes first element from list
        /// </summary>
        /// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
        public void RemoveFirst()
        {
            //If the list is empty
            if (IsEmpty())
            {
                // The list is empty
                Console.WriteLine("Sorry, the list is already empty!");
                return;

            }

            //If there is only one node
            if (Counter == 1)
            {
                //The head and tail are set to null
                Head = null;
                Tail = null;
                return;
            }

            //If there is more than one node
            else
            {
                //The next node from head becomes the new head
                Head = Head.Next;

            }

            //Decrement the count
            Counter--;
        }

        /// <summary>
        /// Removes last element from list
        /// </summary>
        /// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
        public void RemoveLast()
        {
            //If the list is empty
            if (IsEmpty())
            {
                // The list is empty
                Console.WriteLine("Sorry, the list is already empty!");
                return;

            }

            //If there is only one node
            if (Counter == 1)
            {
                //The head and tail are set to null
                Head = null;
                Tail = null;

            }

            else
            {
                //New node that points to the head
                Node current = Head;

                while (current.Next != Tail) //While the second last node is not the tail
                {
                    current = current.Next;//move to the next node
                }

                current.Next = null; //The second last node's is set to null in order to remove it

                Tail = current;//the tail is now the current node
            }
            Counter--;//Decrement the count of nodes
        }

        /// <summary>
        /// Replaces the value  at index.
        /// </summary>
        /// <param name="value">Value to replace.</param>
        /// <param name="index">Index of element to replace.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
        public void Replace(User value, int index)
        {
            if (IsEmpty())
            {
                // The list is empty
                Console.WriteLine("Sorry, the list is empty!");
                return;

            }

            //If the index is out of range
            if (index < 0 || index >= Counter)
            {
                //Throw an exception
                throw new IndexOutOfRangeException("Index out of range");
            }
            //Start from the head
            Node current = Head;

            //If the index is 0
            if (index == 0)
            {
                //Set the value of the head to the value
                current.Data = value;
            }
            else
            {
                //Set current index to 0
                int currentIndex = 0;
                while (currentIndex != index)
                {
                    //Move to the next node
                    current = current.Next;
                    currentIndex++;
                }
                //Set the value of the current node to the value
                current.Data = value;


            }
        }

        //Bonus method
        ///<summary>
        ///Join two or more linked lists together to create a single linked list
        ///</summary>
        ///<param name="nextList">Linked list to join</param>
        ///<exception cref="NullReferenceException">Thrown if list is null.</exception>
        public void Join(SLL nextList)
        {
            //If the list we want to join is empty
            if (nextList.Head == null)
            {
                Console.WriteLine("Sorry, the list wou want to join is empty!");
                return; // Nothing to join
            }

            //If the current list is empty
            if (Head == null)
            {
                //The next list becomes the current list
                Head = nextList.Head;
                Tail = nextList.Tail;
                Counter = nextList.Counter;
            }

            //If the current list is not empty and the next list is not empty
            else
            {
                // Link the current tail to the head of the other list, creating a loop until reaching the end of the other list
                Tail.Next = nextList.Head;
                //Ensure that the tail of the current list is the tail of the other list
                Tail = nextList.Tail;
                //Increment the count
                Counter += nextList.Counter;
            }
        }
    }







}
    



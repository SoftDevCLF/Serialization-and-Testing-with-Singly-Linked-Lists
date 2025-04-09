using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    public class SLL : ILinkedListADT
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Counter { get; set; }

        public SLL()
        {
            Head = null;
            Tail = null;
            Counter = 0;
        }

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

        //Add a node at the beginning
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

        //Add a node at the end
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

        //Clear the list
        public void Clear()
        {
            //The head and tail are set to null, counter is set to 0
            Head = null;
            Tail = null;
            Counter = 0;
        }

        //Check if the list contains the value
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

        //Count the number of nodes
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

        //Return the value of an specific index
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

        //Return the index of the value
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

        //Check if the list is empty
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

        //Remove a node
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

        //Remove the first node
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

        //Remove the last node
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
    }
}


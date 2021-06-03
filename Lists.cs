using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Node
    {
        public Node next;
        
        public Object data;

        public Node previous;

        public override string ToString()
        {
            return (string)data;
        }
    }

    //a doubly linked list
    public class LinkedList
    {
        public Node head;

        public Node tail;

        public int count;
        public LinkedList()
        {
            count = 0;
        }

        public int GetCount()
        {
            return count;
        }

        public void printAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }//end while current is not null
        }//end printAllNodes

        public void AddFirst(Object data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;   //
                head.previous = null; //these two lines arent really needed, since its implicit that they are already null. But this makes it more readable

                tail = head;
            }

            else
            {
                //the node we want to add first
                Node toAdd = new Node();
                toAdd.data = data;

                //the current begining of the list
                Node oldhead = head;

                //link the new node to the old begining
                toAdd.next = oldhead;
                //link the old heads previous to the new head
                oldhead.previous = toAdd;

                //set the head to the new begining
                head = toAdd;
            }

            count++;
        }

        public void AddLast(Object data)
        {
            if (head == null)
            {
                head = new Node();
                head.data = data;
                head.next = null;   //
                head.previous = null; //these two lines arent really needed, since its implicit that they are already null. But this makes it more readable

                tail = head;
            }
            else
            {
                Node toAdd = new Node();
                toAdd.data = data;
                Node oldEnd = tail;

                oldEnd.next = toAdd;    //link the old end to the new end
                toAdd.previous = oldEnd;    //link the new end to the old end
                tail = toAdd;   //change the tail to the new end
            }
            count++;
        }

        public void DeleteLast()
        {
            if (head == null)
            {
                Console.WriteLine("This list has no nodes...");
            }
            else
            {
                Node toDelete = tail;

                toDelete.previous = tail;
                toDelete.previous.next = null;  //delete the reference to toDelete
                toDelete = null; //delete the toDelete

                count--;
            }
        }

    }
}

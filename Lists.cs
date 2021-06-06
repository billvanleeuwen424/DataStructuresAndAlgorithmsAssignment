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

        //O(1)
        //return length of list
        public int GetCount()
        {
            return count;
        }

        //O(N) where n is the length of the list
        //this method just generates a random position between 0 and the size of the list, then passes that position and data to the InsertAt method
        public void InsertAtRandom(Object Data)
        {

            Random rand = new Random();
            int position = rand.Next(count);

            //pass the generated position to the insert method
            InsertAt(Data, position);   //count++ is contained in this method
        }

        //O(n)
        //traverse all nodes in the list, print each to console
        public void PrintAllNodes()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }//end while current is not null
        }//end printAllNodes

        //O(1)
        //add object to the front of the list, point it to the old front, point the head to the new front
        public void AddFirst(Object Data)
        {
            if (head == null)
                StartList(Data);

            else
            {
                //the node we want to add first
                Node toAdd = new Node();
                toAdd.data = Data;

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

        //O(1)
        //add object to the end of the list, change pointings of the .next and .previous, point tail at new end
        public void AddLast(Object Data)
        {
            if (head == null)
                StartList(Data);

            else
            {
                Node toAdd = new Node();
                toAdd.data = Data;
                Node oldEnd = tail;

                oldEnd.next = toAdd;    //link the old end to the new end
                toAdd.previous = oldEnd;    //link the new end to the old end
                tail = toAdd;   //change the tail to the new end
            }
            count++;
        }

        //O(N) where n is the position
        //inserts a node at the position passed
        public void InsertAt(Object Data, int position)
        {
            if (head == null)
                StartList(Data);

            Node toInsert = new Node();
            toInsert.data = Data;

            if (position > count)   //if position passed is larger, just pin to the end
            {
                AddLast(Data);
            }
            else if (position <= 0) //if the position is less than the list or zero, pin to the front
            {
                AddFirst(Data);
            }
            else
            {
                Node current = head;
                for(int i = 0; i < position-1; i++)
                {
                    current = current.next;
                }

                Node nextNode = current.next;

                current.next = toInsert;    //connect node at desired position-1 to new node
                nextNode.previous = toInsert;   //connect node at desired position+1 to new node
                toInsert.previous = current;    //
                toInsert.next = nextNode;   //connect new node to both
            }
            count++;
        }

        //O(1)
        //change pointers, cut the end element off.
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

        //O(N) where N is the length of list2
        public void Merge(LinkedList list2)
        {
            Node list2node = list2.head;

            for (int i=0; i < list2.count; i++)
            {
                AddLast(list2node.data);    //count++ is contained in this method
                list2node = list2node.next;
            }
            list2 = null;
        }




        //if another method finds that there is no head, this static method goes through the quick process to add one.
        //this was added because a lot of other methods use the exact same process
        private void StartList(Object Data)
        {
            head = new Node();
            head.data = Data;
            head.next = null;   //
            head.previous = null; //these two lines arent really needed, since its implicit that they are already null. But this makes it more readable

            tail = head;

        }
    }
}

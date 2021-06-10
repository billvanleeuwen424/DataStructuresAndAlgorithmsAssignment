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
    public class DoubleLinkedList<T>
    {
        public Node head;

        public Node tail;

        public int count;
        public DoubleLinkedList()
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
        public void InsertAtRandom(T Data)
        {

            Random rand = new Random();
            int position = rand.Next(count);

            //pass the generated position to the insert method
            InsertAt(Data, position);   //count++ is contained in this method
        }

        //O(n)
        //traverse all nodes in the list, print each to console
        public void PrintAllForward()
        {
            Node current = head;
            if (head == null)
            {
                Console.WriteLine("List is empty...");
            }
            else
            {
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }//end while current is not null
            }
            
        }

        //O(n)
        //traverse all nodes in the list in reverse, print each to console
        public void PrintAllReverse()
        {
            Node current = tail;
            if (head == null)
            {
                Console.WriteLine("List is empty...");
            }
            else
            {
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.previous;
                }//end while current is not null
            }
        }

        //O(1)
        //add object to the front of the list, point it to the old front, point the head to the new front
        public void AddFirst(T Data)
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
        public void AddLast(T Data)
        {
            if (head == null)
                StartList(Data);

            else
            {
                Node toAdd = new();
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
        public void InsertAt(T Data, int position)
        {
            if (head == null)
                StartList(Data);
            else
            {
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
                    for (int i = 0; i < position - 1; i++)
                    {
                        current = current.next;
                    }

                    Node nextNode = current.next;

                    current.next = toInsert;    //connect node at desired position-1 to new node
                    nextNode.previous = toInsert;   //connect node at desired position+1 to new node
                    toInsert.previous = current;    //
                    toInsert.next = nextNode;   //connect new node to both
                }
            }
            
            count++;
        }

        //O(1)
        //change pointers, cut the end element off.
        public void DeleteLast()
        {
            if (head == null)
            {
                Console.WriteLine("This list has no nodes to delete...");
            }
            else if (tail == head)//last item on list
            {
                Node toDelete = head;
                toDelete = null;
                head = null;
                tail = null;
            }
            else
            {
                Node toDelete = tail;
                Node newTail = toDelete.previous;

                tail = newTail;
                newTail.next = null;  //delete the reference to toDelete
                toDelete = null; //delete the toDelete

                count--;
            }
        }

        //O(1)
        //change pointers, cut the end element off.
        public void DeleteFirst()
        {
            if (head == null)
            {
                Console.WriteLine("This list has no nodes to delete...");
            }
            else if (tail == head)//last item on list
            {
                Node toDelete = head;
                toDelete = null;
                head = null;
                tail = null;
            }
            else
            {
                Node toDelete = head;
                Node newHead = toDelete.next;

                head = newHead;
                newHead.previous = null;  //delete the reference to toDelete
                toDelete = null; //delete the toDelete

                count--;
            }
        }

        //best case, O(1) if the node is the head or the tail, worst case O(N) where N is the positon, if the list needs to be traversed
        //will delete the passed position node. Has checks to prevent against exceptions. Will pass to Deletefirst or Delete last if the node is head or tail
        public void DeletePosition(int position)
        {
            if (head == null)
                Console.WriteLine("This list has no nodes to delete...");

            else if (position > count || position < 0)
                Console.WriteLine("that position does not exist on this list");
            else
            {
                Node toDelete = head;

                for (int i = 0; i < position; i++)  //traverse to position
                {
                    toDelete = toDelete.next;
                }

                //these two ifs make sure head and tail dont go missing, thus destroying the integrity of the linked list
                if (toDelete == tail)
                    DeleteLast();
                else if (toDelete == head)
                    DeleteFirst();


                else
                {
                    Node beforeToDelete = toDelete.previous;
                    Node afterToDelete = toDelete.next;

                    //cut off the toDelete
                    afterToDelete.previous = beforeToDelete;
                    beforeToDelete.next = afterToDelete;

                    toDelete = null;
                    count--;
                }

            }
        }

        //O(1)
        //deletes all items in the list
        public void DeleteAll()
        {
            //clear the head and tail. zero the count. The rest of the nodes are cut off and left to the garbage collector to deal with
            head = null;
            tail = null;
            count = 0;
        }

        //O(1)
        //move the head node to the tail, giving the effect of rotation
        public void RotateLeft()
        {
            if (head == null)
                Console.WriteLine("Cant rotate an empty list");
            else
            {
                Node newTail = head;
                Node newHead = head.next;
                Node oldTail = tail;

                newTail.previous = oldTail;
                oldTail.next = newTail;
                //now it is a circular list
                tail = newTail;
                head = newHead;
                newHead.previous = null;
                newTail.next = null;
                //now it is a regular linked list, rotated one position
            }

        }

        //O(1)
        //move the head node to the tail, giving the effect of rotation
        public void RotateRight()
        {
            if (head == null)
                Console.WriteLine("Cant rotate an empty list");
            else
            {
                Node newHead = tail;
                Node oldHead = head;
                Node newTail = tail.previous;

                newHead.next = oldHead;
                oldHead.previous = newHead;
                //now it is a circular list

                tail = newTail;
                head = newHead;

                newHead.previous = null;
                newTail.next = null;
                //now it is a regular linked list, rotated one position
            }

        }


        //O(N) where N is the length of list2
        //literally just inserts all the items of the second list one after another at the end of the first list
        //deletes the second list when done
        public void Merge(DoubleLinkedList<T> list2)
        {
            Node list2node = list2.head;
            
            for (int i=0; i < list2.count; i++)
            {
                AddLast((T)list2node.data);    //count++ is contained in this method
                list2node = list2node.next;
            }
            list2.DeleteAll();
        }

        //if another method finds that there is no head, this method goes through the quick process to add one.
        //this was added because a lot of other methods use the exact same process
        private void StartList(T Data)
        {
            head = new Node();
            head.data = Data;
            head.next = null;   //
            head.previous = null; //these two lines arent really needed, since its implicit that they are already null. But this makes it more readable

            tail = head;
        }

        //O(N) where N is the number of elements in the list
        //returns the closest bird to a passed position.
        public Bird FindClosest(Position pos)
        {
            Node current = head;

            double gridDistance, closestGridDistance = Double.MaxValue; //assigned at an impossibly high number to reach for animal distance. board max currently is 100*100*10=100000 June 7th 2021
            Bird closest = new Bird();  //creates a null bird with pos 0

           while (current != null)
           {

               Animal tempAnimal = (Animal)current.data;   //this is the bird
               gridDistance = Math.Sqrt(Math.Pow(pos.X - tempAnimal.Pos.X,2) + Math.Pow(pos.Y - tempAnimal.Pos.Y,2) + Math.Pow(pos.Z - tempAnimal.Pos.Z,2));
               if (gridDistance < closestGridDistance)
               {
                   closestGridDistance = gridDistance;
                   closest = (Bird)current.data;
               }

               current = current.next;
           }
            return closest;
        }

        //O(1) 
        //returns the distance as the crow flies from the pos to the object passed
        public double FindDistance(Position pos, Object findDistanceAnimal)
        {
            double distance = Double.MaxValue;

            try
            {
                Animal tempAnimal = (Animal)findDistanceAnimal;

                distance = Math.Sqrt(Math.Pow(pos.X - tempAnimal.Pos.X, 2) + Math.Pow(pos.Y - tempAnimal.Pos.Y, 2) + Math.Pow(pos.Z - tempAnimal.Pos.Z, 2));
            }
            catch (Exception e) //if an exception is thrown, it will probably be casting the object to animal
            {
                Console.WriteLine(e + " " + e.Message); //prints exception and its message
                Console.WriteLine("Debugging only. probably tried to cast something to an animal that wouldnt work....");
            }
            
            return distance;
        }


        //O(N) where N is the position of the bird in the list
        //takes a target passed to it, finds it in the list, deletes it
        //if target isnt in the list, a statement will be printed that says so.
        public void GetEaten(object target)
        {
            Animal tempAnimal = (Animal)target;
            Node current = head;
            bool AnimalWasEaten = false;

            for(int i = 0; i < count; i++)
            {
                if (current.data == tempAnimal)   //delete the Animal from the list
                {
                    DeletePosition(i);
                    AnimalWasEaten = true;

                    i = count;
                }
                else
                    current = current.next;
            }

            if (AnimalWasEaten)
                Console.WriteLine("{0} Was Eliminated...", tempAnimal.ToString());
            else
                Console.WriteLine("That Animal does not exist in this list.... Nothing was deleted");
        }
    }
}

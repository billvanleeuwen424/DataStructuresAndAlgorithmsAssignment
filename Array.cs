using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class ArrayList<T>
    {
        public T[] array;
        private int next = 0;   //the next empty position in the array... also can be used as a count of items in the array

        public int GetCount()
        {
            return next;
        }

        //constructor
        //makes a size 1 array
        public ArrayList()
        {
            array = new T[1];
        }
        //constructor
        //makes an array of a specified size
        public ArrayList(int size)
        {
            array = new T[size];
        }

        //O(N) where N is the size of the array
        //creates a new array double the size of the previous and injects each item in its original order into it.
        private void Grow()
        {
            T[] newarray; 

            //check if array is empty or not, if it is, give it size 2;
            if (array.Length == 0)
                newarray = new T[2];
            else
                newarray = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                newarray[i] = array[i];
            }

            array = newarray;
        }

        //passes position zero and the data to insert
        public void AddFront(T data)
        {
            Insert(data, 0);
        }
        //passes the next open positon to insert
        public void AddLast(T data)
        {
            Insert(data, next);
        }

        //O(1) but O(N) inside the Insert method.
        //passes the position to insert
        public void InsertBefore(T data, int before)
        {
            Insert(data, before - 1); //just pases it to the insert method
        }

        //O(N) where N is length of the items to the right of the desired position
        //moves each item to the right by one position, increases list size if needed, then inserts item.
        private void Insert(T data, int position)
        {
            if(array.Length == 0)   //protect against 0 size arrays
            {
                Grow();
            }
            if (next == 0) //if array is empty
            {
                array[0] = data;
            }
            else if (position == next)  //if the data is to be added to the end of the list
            {
                if (next >= array.Length) //if the next element will out of bounds the array
                    Grow();
                array[next] = data;
            }
            else
            {
                //try, catch, finally section to block entries outside of the 'arraylists' bounds
                try
                {
                    if (position > next)
                        throw new IndexOutOfRangeException("desired position is larger than the array");
                    if (position < 0)
                        throw new IndexOutOfRangeException("desired position is less than zero");

                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    position = next;
                }
                finally
                {
                    if (next >= array.Length) //if the next element will out of bounds the array
                        Grow();

                    for (int i = next; i != position; i--)  //start at the end of the array, move each item to the right
                    {
                        array[i] = array[i - 1];
                    }

                    array[position] = data;
                }
            }
            next++;
        }

        //O(N) where N is the length of the list
        //shifts every entry in the array over to the left one. 
        // implicitly deletes the [0] entry, since it is overwritten.
        public void DeleteFirst()
        {
            try
            {
                IsArrayEmpty();

                for (int i = 0; i < next - 1; i++)  //move every array item over one left until you get to the end
                {
                    array[i] = array[i + 1];
                }
                next--;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("{0} cannot delete items from an empty array", e.Message);
            }
        }

        //O(1)
        //deletes the last item of the list
        public void DeleteLast()
        {
            try
            {
                IsArrayEmpty();

                array[next - 1] = default;
                //while this doesnt delete the last element explicitly, it sets it to the default for that datatype ie int = 0.
                //also when the next-- comes next, the item will be unaccessable.
                next--;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("{0} cannot delete items from an empty array", e.Message);
            }
        }

        //O(N) where N is the amount of items in the array
        //returns every list item to default for its type. catches if the list is empty.
        public void DeleteAll()
        {
            try
            {
                IsArrayEmpty();

                int listlength = GetCount();

                for (int i = 0; i < listlength; i++)
                {
                    array[i] = default;
                }
                next = 0;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("{0} there are no items to delete.", e.Message);
            }
        }

        //O(N) where N is the length of the list
        //assigns the first element of the array to a holder, shifts everything over, puts the holder at the end.
        public void RotateLeft()
        {
            try
            {
                IsArrayEmpty();

                T holder = array[0];

                for (int i = 0; i < next - 1; i++)  //move every array item over one left until you get to the end
                {
                    array[i] = array[i + 1];
                }

                array[next - 1] = holder;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("{0} rotation left is impossible.", e.Message);
            }
        }



        //O(N) where N is the length of the list
        //assigns the last element of the array to a holder, shifts everything over, puts the holder at the beginning.
        public void RotateRight()
        {
            try
            {
                IsArrayEmpty();

                T holder = array[next - 1];

                for (int i = next - 1; i != 0; i--)
                {
                    array[i] = array[i - 1];
                }

                array[0] = holder;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("{0} rotation right is impossible.", e.Message);
            }

        }

        //O(1)
        //takes to indicies of the array, assigns object two to a holder, assigns object one to position two
        //assigns the holder(object two) to position one
        public void Swap(int one, int two)
        {
            try
            {
                IsArrayEmpty();

                if (one > next - 1 || one < 0)   //
                {
                    throw new IndexOutOfRangeException("1st");
                }
                else if (two > next - 1 || two < 0)  //if entered indicies one or two are out of bounds, dont switch
                {
                    throw new IndexOutOfRangeException("2nd");
                }

                T tempHolder = array[two];
                array[two] = array[one];
                array[one] = tempHolder;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("{0} index entry out of bounds, Swap terminated.", e.Message);
            }
        }

        //O(N) where N is the length of the array
        //just returns a nicely formatted string of every object in the array and its index
        public string PrintAllForward()
        {
            try
            {
                IsArrayEmpty();

                int listlength = GetCount();
                string printer = "";

                for (int i = 0; i < listlength; i++)
                {
                    printer += "[" + i + " : " + array[i].ToString() + "]" + '\n';
                }
                return printer;
            }
            catch (IndexOutOfRangeException e)
            {
                return e.Message;
            }

        }

        //O() unknown
        //sorts the array by animal name
        public void InPlaceSort()
        {
            Array.Sort(array,0 , GetCount()); //this overload only sorts the part of the array we want
        }

        //O(N) where N is the length of the array
        //just returns a nicely formatted string of every object in the array and its index, but in reverse
        public string PrintAllReverse()
        {
            try
            {
                int listlength = GetCount();
                string printer = "";

                for (int i = listlength - 1; i >= 0; i--)
                {
                    printer += "[" + i + " : " + array[i].ToString() + "]" + '\n';
                }

                return printer;
            }
            catch (IndexOutOfRangeException e)
            {
                return e.Message;
            }

        }

        //private method to check if array is empty, throws exception if it is, rethrows it up.
        private void IsArrayEmpty()
        {
            try
            {
                if (next == 0)
                    throw new IndexOutOfRangeException("Array is empty.");
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }

        /// <summary>
        /// O(N+M) where N is the length of list1, and M is the length of list2
        /// //merges two arraylists and returns it
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static ArrayList<T> ArrayListMerge(ArrayList<T> list1, ArrayList<T> list2)
        {

            int list1length = (list1.GetCount());
            int list2length = (list2.GetCount());
            int newListLength = (list1length + list2length);

            ArrayList<T> list3 = new(newListLength);   //build new list of size list1+list2

            //insert every item of list 1 into list3, increment the next operator eachtime
            for (int i = 0; i < list1length; i++)
            {
                list3.array[i] = list1.array[i];
                list3.next++;
            }

            //add every element from list2 after the elements from list1
            int j = list3.next;
            for (int i = 0; i < list2length; i++)
            {
                list3.array[j] = list2.array[i];
                j++;
                list3.next++;
            }
            return list3;
        }

        /// <summary>
        /// O(N+M) where N is the length of list1, and M is the length of list2
        /// overload where user can choose to delete the old lists
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <param name="deleteOldLists"></param>
        /// <returns></returns>
        public static ArrayList<T> ArrayListMerge(ArrayList<T> list1, ArrayList<T> list2, bool deleteOldLists)
        {

            int list1length = (list1.GetCount());
            int list2length = (list2.GetCount());
            int newListLength = (list1length + list2length);

            ArrayList<T> list3 = new(newListLength);   //build new list of size list1+list2

            //insert every item of list 1 into list3, increment the next operator eachtime
            for (int i = 0; i < list1length; i++)
            {
                list3.array[i] = list1.array[i];
                list3.next++;
            }


            //add every element from list2 after the elements from list1
            int j = list3.next;
            for (int i = 0; i < list2length; i++)
            {
                list3.array[j] = list2.array[i];
                j++;
                list3.next++;
            }

            //sends lists to be deleted 
            if (deleteOldLists == true)
            {
                list1.DeleteAll();
                list2.DeleteAll();
            }

            return list3;
        }
    }
}

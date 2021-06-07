using System;
using System.IO;
using System.Collections.Generic;


namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //create array for cat names with length of list
            string[] catNames = new string[100];
            ReadCatNames(catNames);
            //vice versa but with length of snake names
            string[] snakeNames = new string[35];
            ReadSnakeNames(snakeNames);



            //catArray.AddLast(RandCat(catNames));
            //snakeArray.AddLast(RandSnake(snakeNames));
            //catArray.AddLast(RandCat(catNames));
            //snakeArray.AddLast(RandSnake(snakeNames));

            //Console.WriteLine("snake array with two objects:\n{0}", snakeArray.PrintAllForward());
            //Console.WriteLine("cat array with two objects:\n{0}", catArray.PrintAllForward());

            //catArray.InsertBefore(RandCat(catNames), 2);
            //snakeArray.InsertBefore(RandSnake(snakeNames), 2);

            //Console.WriteLine("snake array with three objects. New object should be in the center:\n{0}", snakeArray.PrintAllForward());
            //Console.WriteLine("cat array with three objects. New object should be in the center:\n{0}", catArray.PrintAllForward());


            ArrayList<Animal> snakeArray = new(5);
            ArrayList<Animal> catArray = new(5);

            //generate 5 of each cat and snake, load into an array
            for (int i = 0; i < 5; i++)
            {
                catArray.AddLast(RandCat(catNames));
            }
            for (int i = 0; i < 5; i++)
            {
                snakeArray.AddLast(RandSnake(snakeNames));
            }

            snakeArray.InPlaceSort();
            catArray.InPlaceSort();





            //Console.WriteLine("snake array with 5 objects sorted: \n{0}", snakeArray.PrintAllForward());
            //Console.WriteLine("cat array with 5 objects sorted: \n{0}", catArray.PrintAllForward());

            //snakeArray.DeleteAll();
            //catArray.DeleteAll();

            //Console.WriteLine("snake array after DeleteAll: \n{0}", snakeArray.PrintAllForward());
            //Console.WriteLine("cat array after DeleteAll: \n{0}", catArray.PrintAllForward());

            //Console.WriteLine("\n\nTest on an empty array");
            //ArrayList<Animal> snakeArray2 = new(5);
            //ArrayList<Animal> catArray2 = new(5);

            //snakeArray.DeleteAll();
            //catArray.DeleteAll();


            //ArrayList<Animal> catsAndSnakesArray = ArrayList<Animal>.ArrayListMerge(snakeArray, catArray);

            //Console.WriteLine("merged array: \n{0}", catsAndSnakesArray.PrintAllForward());

            //Console.WriteLine("\nShowing that both old arrays still exist");
            //Console.WriteLine("snake array: \n{0}", snakeArray.PrintAllForward());
            //Console.WriteLine("cat array: \n{0}", catArray.PrintAllForward());

            //Console.WriteLine("\nShowing the delete overload");
            //ArrayList<Animal> catsAndSnakesArray2 = ArrayList<Animal>.ArrayListMerge(snakeArray, catArray, true);

            //Console.WriteLine("merged array: \n{0}", catsAndSnakesArray.PrintAllForward());

            //Console.WriteLine("snake array: \n{0}", snakeArray.PrintAllForward());
            //Console.WriteLine("cat array: \n{0}", catArray.PrintAllForward());



            //Console.WriteLine("\n\nA test to see if it will stop swaps on an empty array");
            //ArrayList<Animal> snakeArray2 = new(5);
            //ArrayList<Animal> catArray2 = new(5);
            //snakeArray2.RotateLeft();
            //catArray2.RotateLeft();
            //snakeArray2.RotateRight();
            //catArray2.RotateRight();


            //Console.WriteLine("\n\nA test to see if it will stop indicies from outside of the array");
            //Console.WriteLine("below 0 test");
            //snakeArray.Swap(-1, 4);
            //catArray.Swap(-1, 4);
            //Console.WriteLine("above size of array test");
            //snakeArray.Swap(1, 40);
            //catArray.Swap(1, 40);
            //Console.WriteLine("\nShowing that the swaps were terminated");
            //Console.WriteLine("snake array with 5 objects sorted: \n{0}", snakeArray.PrintAllForward());
            //Console.WriteLine("cat array with 5 objects sorted: \n{0}", catArray.PrintAllForward());

            /*
            Console.WriteLine(catArray.PrintAllForward());
            Console.WriteLine(snakeArray.PrintAllForward());
            Console.WriteLine(snakeArray.PrintAllReverse());

            ArrayList<BadGuys> catsnakearray = ArrayList<BadGuys>.ArrayListMerge(catArray, snakeArray, true);

            Console.WriteLine(catsnakearray.PrintAllForward());

            catsnakearray.InPlaceSort();

            Console.WriteLine(catsnakearray.PrintAllForward());

            catsnakearray.RotateRight();

            Console.WriteLine("Rotated right \n {0}",catsnakearray.PrintAllForward());

            catsnakearray.RotateLeft();

            Console.WriteLine("Rotated left \n {0}",catsnakearray.PrintAllForward());

            catsnakearray.DeleteFirst();

            Console.WriteLine("Rotated left \n {0}", catsnakearray.PrintAllForward());
           
            LinkedList<Snake> snakelist = new LinkedList<Snake>(snakeArray);
            LinkedList<Cat> catlist = new LinkedList<Cat>(catArray);

            //print all
            Console.WriteLine("Snake Array:");
            foreach (Snake i in snakeArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nCat Array:");
            foreach (Cat i in catArray)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nSnake Linked List:");
            foreach (Snake i in snakelist)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nCat Linked List:");
            foreach (Cat i in catlist)
            {
                Console.WriteLine(i);
            }
            */


            /*TESTING SECTION*/
            /*
            //testing for position setting
            Console.WriteLine("\n\nTesting postion class....");
            Console.WriteLine("Testing 0 arg constructor");
            Position testPos0 = new Position();
            Console.WriteLine("testPos0: {0} .... 0 arg constructor .... Value should be 0, 0, 0", testPos0);
            Console.WriteLine("Testing 3 arg constructor.....");
            Position testPos1 = new Position(1, 2, 3);
            Console.WriteLine("testPos1: {0} .... Value set to 1,2,3 .... Value should be 1, 2, 3", testPos1);
            Console.WriteLine("Testing Below 0 Clamping.....");
            Position testPos2 = new Position(-5.8, -5.5, -1.4);
            Console.WriteLine("testPos2: {0} .... Value set to -5.8, -5.5, -1.4 .... Value should be 0, 0, 0", testPos2);
            Position testPos3 = new Position(17.3, 100, 76);
            Console.WriteLine("Testing above 10 Clamping....");
            Console.WriteLine("testPos3: {0} .... Value set to 17.3, 100, 76 .... Value should be 10, 10, 10", testPos3);

            //testing for Positon.Move
            Console.WriteLine("\nTesting basic movement....");
            testPos0.Move(1, 1, 1);
            Console.WriteLine("testPos0: {0} .... move 1 in each direction .... Value should be 1, 1, 1", testPos0);
            testPos0.Move(3, 3, 3);
            Console.WriteLine("testPos0: {0} .... move 3 in each direction .... Value should be 4, 4, 4", testPos0);
            Console.WriteLine("Testing Above 10 clamping....");
            testPos0.Move(-3, -3, -3);
            Console.WriteLine("testPos0: {0} .... move -3 in each direction .... Value should be 1, 1, 1", testPos0);
            Console.WriteLine("Testing Above 10 clamping....");
            testPos1.Move(100, 100, 100);
            Console.WriteLine("testPos1: {0} .... move 100 in each direction .... Value should be 10, 10, 10", testPos1);
            Console.WriteLine("Testing Below 0 clamping....");
            testPos2.Move(-100, -100, -100);
            Console.WriteLine("testPos2: {0} .... move -100 in each direction .... Value should be 0, 0, 0", testPos2);

            //testing moving of the cats
            Console.WriteLine("\nCat.Move() Testing...");
            catArray[0].Move(-100, -100, -100);
            Console.WriteLine("CatArray[0]: {0} .... move -100 in each direction .... Value should be 0, 0, 0", catArray[0]);
            catArray[0].Move(+100, +100, +100);
            Console.WriteLine("CatArray[0]: {0} .... move +100 in each direction .... Value should be 10, 10, 10", catArray[0]);
            catArray[0].Move(-3, -2, -1);
            Console.WriteLine("CatArray[0]: {0} .... move -3x, -2y, -1z .... Value should be 7, 8, 9", catArray[0]);
            catArray[0].Move(1, 1, 1);
            Console.WriteLine("CatArray[0]: {0} .... move +1 in each direction .... Value should be 8, 9, 10", catArray[0]);

            //testing moving of the snake
            Console.WriteLine("\nSnake.Move() Testing...");
            snakeArray[0].Move(-100, -100, -100);
            Console.WriteLine("SnakeArray[0]: {0} .... move -100 in each direction .... Value should be 0, 0, 0", snakeArray[0]);
            snakeArray[0].Move(+100, +100, +100);
            Console.WriteLine("SnakeArray[0]: {0} .... move +100 in each direction .... Value should be 10, 10, 10", snakeArray[0]);
            snakeArray[0].Move(-3, -2, -1);
            Console.WriteLine("SnakeArray[0]: {0} .... move -3x, -2y, -1z .... Value should be 7, 8, 9", snakeArray[0]);
            snakeArray[0].Move(1, 1, 1);
            Console.WriteLine("SnakeArray[0]: {0} .... move +1 in each direction .... Value should be 8, 9, 10", snakeArray[0]);
            */
        }

        /// <summary>
        /// generates a random snake. Just needs the name array passed from main.
        /// </summary>
        /// <param name="snakeNames"></param>
        /// <returns></returns>
        static Snake RandSnake(string[] snakeNames)
        {
            Random rnd = new Random();

            double x = RandPos(), y = RandPos(), z = RandPos(); //set positions
            bool venomous = rnd.Next(2) == 0; //set venomous
            Snake randomSnake = new Snake(snakeNames[rnd.Next(35)], rnd.Next(100), rnd.Next(100), x, y, z, rnd.Next(10), venomous);

            return randomSnake;
        }

        /// <summary>
        /// generates a random cat. Just needs the name array passed from main.
        /// </summary>
        /// <param name="catNames"></param>
        /// <returns></returns>
        static Cat RandCat(string[] catNames)
        {
            Random rnd = new Random();

            double x = RandPos(), y = RandPos(), z = RandPos(); //set positions
            int breed = rnd.Next(6);
            Cat randomCat = new Cat(catNames[rnd.Next(100)], rnd.Next(100), rnd.Next(100), x, y, z, breed);

            return randomCat;
        }

        /// <summary>
        /// returns a random floating point number, between 0 and 10.
        /// Should be used when setting positons for snakes/cats/animals etc
        /// </summary>
        /// <returns>a double between 0 and 10</returns>
        static double RandPos()
        {
            Random rand1 = new Random();

            return rand1.NextDouble() * rand1.Next(5, 10);
            //random ints from 5 to 10. I first tried 1 to 10, but the random generations trended strongly toward 0
        }

        /// <summary>
        /// takes array (should be blank), fills it with the cat names from the txt file
        /// </summary>
        /// <param name="catNames"></param>
        /// <returns></returns>
        static string[] ReadCatNames(string[] catNames)
        {
            //enter file into filestream and streamreader
            string path = "..\\..\\..\\..\\catnames.txt";   //this is a relative file path to the Assignment1 Folder
            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            //set delimeter between number and catname
            const char DELIM = ' ';

            //create array for the lines on txt
            string[] fields;

            string recordIn = reader.ReadLine();    //declare variable to hold read text... read first line
            //will loop until end of names in txt
            for (int i = 0; recordIn != null; i++)
            {
                fields = recordIn.Split(DELIM);

                catNames[i] = fields[2];
                //read next line
                recordIn = reader.ReadLine();
            }

            return catNames;
        }

        /// <summary>
        /// takes array (should be blank), fills it with the snake names from the txt file
        /// </summary>
        /// <param name="snakeNames"></param>
        /// <returns></returns>
        static string[] ReadSnakeNames(string[] snakeNames)
        {
            //enter file into filestream and streamreader
            string path = "..\\..\\..\\..\\snakenames.txt";   //this is a relative file path to the Assignment1 Folder
            FileStream inFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            //create string for the lines on txt
            string fields;

            string recordIn = reader.ReadLine();    //declare variable to hold read text... read first line
            //will loop until end of names in txt
            for (int i = 0; recordIn != null; i++)
            {
                fields = recordIn;

                snakeNames[i] = fields;
                //read next line
                recordIn = reader.ReadLine();
            }

            return snakeNames;
        }
    }
}

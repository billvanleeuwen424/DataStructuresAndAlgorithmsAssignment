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
            //bird names
            string[] birdNames = new string[10] {"Tweety", "Zazu", "Iago", "Hula", "Manu", "Couscous", "Roo", "Tookie", "Plucky", "Jay"};

            //init arrays
            ArrayList<Animal> snakeArray = new(3);
            ArrayList<Animal> catArray = new(3);

            //fill arrays
            catArray.AddFront(RandCat(catNames));
            snakeArray.AddLast(RandSnake(snakeNames));  //left one cat and one bird here for ease of testing

            //merge both and sort it
            ArrayList<Animal> snakecatArray = ArrayList<Animal>.ArrayListMerge(snakeArray, catArray);
            snakecatArray.InPlaceSort();

            //print merged array
            //Console.WriteLine("Print Forward");
            //Console.WriteLine(snakecatArray.PrintAllForward());
            //Console.WriteLine("Print Reverse");
            //Console.WriteLine(snakecatArray.PrintAllReverse());


            //create 2 bird lists
            DoubleLinkedList<Bird> Bird1 = new();
            for(int i=0; i < 1; i++)
            {
                Bird tempBird = RandBird(birdNames[i]); //
                Bird1.AddLast(tempBird);
            }
            DoubleLinkedList<Bird> Bird2 = new();
            for (int i = 0; i < 1; i++)
            {
                Bird tempBird = RandBird(birdNames[i + 5]); //removed 8 birds here for ease of testing
                Bird2.AddLast(tempBird);
            }
            //merge into bird1
            Bird1.Merge(Bird2);

            ////print forward and back
            //Console.WriteLine("Print Forward");
            //Bird1.PrintAllForward();
            //Console.WriteLine("Print Reverse");
            //Bird1.PrintAllReverse();


            //debugging section***************************************************

            Bird bird1 = (Bird)Bird1.head.data;
            Bird bird2 = (Bird)Bird1.tail.data;

            Animal badguy1 = snakecatArray.array[0];
            Animal badguy2 = snakecatArray.array[1];

            //put animals in basic ass positions to see where they go
            bird1.Pos.X = 0;
            bird1.Pos.Y = 0;
            bird1.Pos.Z = 0;
            bird2.Pos.X = 0;
            bird2.Pos.Y = 0;
            bird2.Pos.Z = 0;
            badguy1.Pos.X = 100;
            badguy1.Pos.Y = 100;
            badguy2.Pos.X = 100;
            badguy2.Pos.Y = 100;




            Console.WriteLine("\n\n\n\n\n\n\n\n");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("WELCOME TO THE SIMULATION");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\n\n");

            int roundnum = 0;
            while (Bird1.count != 0) //continue until bird list is empty
            {
                Console.WriteLine("Round {0}", roundnum);

                //birds/snakes movement and eating
                for(int i = 0;  i < snakecatArray.GetCount(); i++)
                {
                    Animal eaterAnimal = snakecatArray.array[i];

                    //find closest bird and find its distance
                    Bird closestBird = Bird1.FindClosest(eaterAnimal.Pos);
                    double distancefromclosestbird = Bird1.FindDistance(eaterAnimal.Pos, closestBird);

                    //if the closest bird is in range of the snake/cat
                    if(distancefromclosestbird < eaterAnimal.Range)
                    {
                        eaterAnimal.Eat(closestBird);   //prints eating
                        Bird1.GetEaten(closestBird);   //removes bird from the list
                    }
                    else    //no birds in range
                    {
                        //see paper written equation on the word doc associated with this assignment. 
                        //it has an example of this math below

                        //distance x and distance y
                        double dx = closestBird.Pos.X - eaterAnimal.Pos.X;
                        double dy = closestBird.Pos.Y - eaterAnimal.Pos.Y;

                        double xyDistance = Math.Sqrt(dx * dx + dy * dy);   //only xy distance from bird linearly

                        double block;  //each block of distance to move, also could be seen as steps


                        if(dx+dy == 0)  //avoid dividebyzero
                        {
                            block = 0;
                        }
                        //if the distance is less than the speed. Here so that the animal wont move past the bird
                        else if (xyDistance < eaterAnimal.Speed)
                            block = xyDistance / (dx + dy);
                        else
                            block = eaterAnimal.Speed / (dx + dy);

                        //move one block for each change in x and y
                        double moveX = block * dx;
                        double moveY = block * dy;

                        eaterAnimal.Move(moveX,moveY);   //move towards bird
                    }
                }

                //move all birds randomly
                Node currentBird = Bird1.head;
                while(currentBird != Bird1.tail)
                {
                    Bird currentBirdBird = (Bird)currentBird.data;

                    currentBirdBird.Move();

                    currentBird = currentBird.next;
                }
                roundnum++;

                Console.WriteLine("Birds\n");
                Bird1.PrintAllForward();
                Console.WriteLine("Snakes and cats\n");
                Console.WriteLine(snakecatArray.PrintAllForward());


                Console.Read(); //to pause until next round
            }

            Console.WriteLine("This Simulation took {0} rounds for all of the birds to be eaten..", roundnum);
        }

        /// <summary>
        /// generates a random snake. Just needs the name array passed from main.
        /// </summary>
        /// <param name="snakeNames"></param>
        /// <returns></returns>
        static Snake RandSnake(string[] snakeNames)
        {
            Random rnd = new Random();

            bool venomous = rnd.Next(2) == 0; //set venomous
            Snake randomSnake = new Snake(snakeNames[rnd.Next(35)], rnd.Next(100), rnd.Next(100), true, rnd.Next(10), venomous);

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

            int breed = rnd.Next(6);
            Cat randomCat = new Cat(catNames[rnd.Next(100)], rnd.Next(100), rnd.Next(100), true, breed);

            return randomCat;
        }

        /// <summary>
        /// generates a random bird. Just needs the name array passed from main.
        /// </summary>
        /// <returns></returns>
        static Bird RandBird(string[] birdNames)
        {
            Random rnd = new Random();

            Bird randomBird = new Bird(birdNames[rnd.Next(10)], rnd.Next(100), rnd.Next(100), true);

            return randomBird;
        }

        /// <summary>
        /// generates a random bird. Just needs the namepassed from main.
        /// //differs from RandBird in that it only wants the string not the array.
        /// </summary>
        /// <returns></returns>
        static Bird RandBird(string birdName)
        {
            Random rnd = new Random();

            Bird randomBird = new Bird(birdName, rnd.Next(100), rnd.Next(100), true);

            return randomBird;
        }

        /// <summary>
        /// returns a random floating point number, between 5 and 10.
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

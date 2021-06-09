using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// a 3 dimensional position class.
    /// 
    /// 
    /// constructors:
    /// 0 arg
    /// 3 arg (double x, double y, double z)
    /// 
    /// methods:
    /// Move(double, double, double)
    /// changes x,y,z by amnount. clamps between 0 and 10
    /// 
    /// ToString()
    /// </summary>
    public class Position
    {
        private double x, y, z;

        //max size of the board variables.
        private static readonly double minX = -100, minY = -100, minZ = 0;
        private static readonly double maxX = 100, maxY = 100, maxZ = 10;


        /// <summary>
        /// x property
        /// </summary>
        public double X
        {
            get { return x; }

            //only allows values between minX and maxX
            //if too far low or high, sets to minX and maxX respectively
            set
            {
                if (value > maxX)
                    x = maxX;
                else if (value < minX)
                    x = minX;
                else
                    x = value;
            }
        }

        /// <summary>
        /// z property
        /// </summary>
        public double Z
        {
            get { return z; }

            //only allows values between minZ and maxZ
            //if too far low or high, sets to minZ and maxZ respectively
            set
            {
                if (value > maxZ)
                    z = maxZ;
                else if (value < minZ)
                    z = minZ;
                else
                    z = value;
            }
        }

        /// <summary>
        /// y property
        /// </summary>
        public double Y
        {
            get { return y; }

            //only allows values between minY and maxY
            //if too far low or high, sets to minY and maxY respectively
            set
            {
                if (value > maxY)
                    y = maxY;
                else if (value < minY)
                    y = minY;
                else
                    y = value;
            }
        }

        /// <summary>
        /// sets all initiated position objects to 0,0,0
        /// </summary>
        public Position()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        /// <summary>
        /// 3 argument constructor
        /// </summary>
        /// <param name="Xs">x position</param>
        /// <param name="Ys">y position</param>
        /// <param name="Zs">z position</param>
        public Position(double Xs, double Ys, double Zs)
        {
            //set position of charachters by Xs,Ys,Zs
            //wont allow setting larger or smaller than the board
            //passes through property also for double security
            if (Xs > maxX)
                X = maxX;
            else if (Xs < minX)
                X = minX;
            else
                X = Xs;
            if (Ys > maxY)
                Y = maxY;
            else if (Ys < minY)
                Y = minY;
            else
                Y = Ys;
            if (Zs > maxZ)
                Z = maxZ;
            else if (Zs < minZ)
                Z = minZ;
            else
                Z = Zs;
        }


        /// <summary>
        /// method for changing the position of a game object
        /// </summary>
        /// <param name="dx">movement of x</param>
        /// <param name="dy">movement of y</param>
        /// <param name="dz">movement of y</param>
        public void Move(double dx, double dy, double dz)
        {
            //changes position of charachters by dx,dy,dz
            //wont allow movement larger or smaller than the board
            //passes through property for double security
            if ((dx + X) > maxX)
                X = maxX;
            else if ((dx + X) < minX)
                X = minX;
            else
                X += dx;
            if ((dy + Y) > maxY)
                Y = maxY;
            else if ((dy + Y) < minY)
                Y = minY;
            else
                Y += dy;
            if ((dz + Z) > maxZ)
                Z = maxZ;
            else if ((dz + Z) < minZ)
                Z = minZ;
            else
                Z += dz;
        }


        /// <summary>
        /// Static method to give animals their starting positions.
        /// gives different positions depending on the type of animal
        /// </summary>
        /// <param name="tempAnimal"></param>
        /// <returns></returns>
        public static Position StartingPostion(Animal tempAnimal)
        {
            Position pos = new Position();
            Random rand = new Random();


            int maxstart = tempAnimal.maxStartXY;
            int maxheight = tempAnimal.maxHeightZ;

            //random gen description
            //generate random number between 0 and 1, multiply by two and -1 // this generates a random double between -1 and 1
            //multiply that by a random number between 0 and its maximum start location
            pos.x = ((rand.NextDouble() * 2 - 1) * rand.Next(0,maxstart));
            pos.y = ((rand.NextDouble() * 2 - 1) * rand.Next(0, maxstart));
            pos.z = ((rand.NextDouble() * 2 - 1) * rand.Next(0, maxheight));    //if temp animal does not fly, its max height is zero, thus z = 0

            return pos;
        }

        //basic ToString
        public override string ToString()
        {
            return "(X=" + x.ToString("F") + " Y=" + y.ToString("F") + " Z=" + z.ToString("F") + ")";
        }
    }
}

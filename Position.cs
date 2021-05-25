using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// a 3 dimensional position class.
    /// allows settting from 0-10 for all x,y,z
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

        /// <summary>
        /// x property
        /// </summary>
        public double X
        {
            get { return x; }

            //only allows values between 0 and 10
            //if too far low or high, sets to 0 or 10 respectively
            set
            {
                if (value > 10.0)
                    x = 10.0;
                else if (value < 0)
                    x = 0;
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

            //only allows values between 0 and 10
            //if too far low or high, sets to 0 or 10 respectively
            set
            {
                if (value > 10.0)
                    z = 10.0;
                else if (value < 0)
                    z = 0;
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

            //only allows values between 0 and 10
            //if too far low or high, sets to 0 or 10 respectively
            set
            {
                if (value > 10.0)
                    y = 10.0;
                else if (value < 0)
                    y = 0;
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
            //set position of charachters by dx,dy
            //wont allow setting larger or smaller than the board
            //passes through property also for double security
            if (Xs > 10)
                X = 10;
            else if (Xs < 0)
                X = 0;
            else
                X = Xs;
            if (Ys > 10)
                Y = 10;
            else if (Ys < 0)
                Y = 0;
            else
                Y = Ys;
            if (Zs > 10)
                Z = 10;
            else if (Zs < 0)
                Z = 0;
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
            if ((dx + X) > 10)
                X = 10;
            else if ((dx+X) < 0)
                X = 0;
            else 
                X += dx;
            if ((dy + Y) > 10)
                Y = 10;
            else if ((dy + Y) < 0)
                Y = 0;
            else 
                Y += dy; 
            if ((dz + Z) > 10)
                Z = 10;
            else if ((dz + Z) < 0)
                Z = 0;
            else 
                Z += dz;
        }



        //basic ToString
        public override string ToString()
        {
            return "(X=" + x.ToString("F") + " Y=" + y.ToString("F") + " Z=" + z.ToString("F") + ")";
        }
    }
}

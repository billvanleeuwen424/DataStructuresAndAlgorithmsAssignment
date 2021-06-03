using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// a subclass of animal.
    /// 
    /// adds: double length and boolean venomous
    /// </summary>
    public class Snake : BadGuys
    {
        private double length;
        private bool venomous;

        //overridden speed from animal class
        private new int speed = 5;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public bool Venomous
        {
            get { return venomous; }
            set { venomous = value; }
        }

        public Snake()
        {

        }
        /// <summary>
        /// positon only constructor. Length set to 1
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        public Snake(double xpos, double ypos, double zpos)
        {
            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;

            Length = 1;
        }

        /// <summary>
        /// 6 arg constructor. Length set to 1
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        public Snake(string name, double age, int id, double xpos, double ypos, double zpos)
        {
            this.age = age;
            this.id = id;
            this.name = name;

            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;

            Length = 1;
        }

        /// <summary>
        /// 7 arg constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        /// <param name="length"></param>
        public Snake(string name, double age, int id, double xpos, double ypos, double zpos, double length)
        {
            this.age = age;
            this.id = id;
            this.name = name;

            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;

            Length = length;
        }

        /// <summary>
        /// full arg constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        /// <param name="length"></param>
        /// <param name="venom"></param>
        public Snake(string name, double age, int id, double xpos, double ypos, double zpos, double length, bool venom)
        {
            this.age = age;
            this.id = id;
            this.name = name;

            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;

            Length = length;
            Venomous = venom;
        }

        /// <summary>
        /// dz is defaulted zero because snakes cant use z
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
        public override void Move(double dx, double dy, double dz = 0)
        {
            pos.Move(dx, dy, dz);
        }

        public override string ToString()
        {
            //checks to be sure position has been given a value
            if (pos == null)
                return "Name: " + name + " Age: " + age + " ID: " + id + " Venomous? " + venomous + " Length: " + length + " Position: " + " N/A";
            else
                return "Name: " + name + " Age: " + age + " ID: " + id + " Venomous? " + venomous + " Length: " + length + " Position: " + pos.ToString();
        }
    }
}

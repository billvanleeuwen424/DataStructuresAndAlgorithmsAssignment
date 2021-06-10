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
    public class Snake : Animal
    {
        private double length;
        private bool venomous;

        private readonly int speed = 14;
        private readonly int range = 3;

        public override int Speed
        {
            get { return speed; }
        }

        public override int Range
        {
            get { return range;  } 
        }
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
        /// full constructor using the static positon generator. if false, position will default to zero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="generatepos"></param>
        /// <param name="length"></param>
        /// <param name="venom"></param>
        public Snake(string name, double age, int id, bool generatepos, double length, bool venom)
        {
            this.age = age;
            this.id = id;
            this.name = name;
            Length = length;
            Venomous = venom;

            if (generatepos)
            {
                pos = Position.StartingPostion(this);
            }
            else
            {
                pos.X = 0;
                pos.Y = 0;
                pos.Z = 0;
            }
        }

        public override string ToString()
        {
            //checks to be sure position has been given a value
            if (pos == null)
                return "Name: " + name + " Age: " + age + " ID: " + id + " Venomous? " + venomous + ". Length: " + length + " Position: " + " N/A";
            else
                return "Name: " + name + " Age: " + age + " ID: " + id + " Venomous? " + venomous + ". Length: " + length + " Position: " + pos.ToString();
        }
    }
}

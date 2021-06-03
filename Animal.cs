using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// a superclass to be used by any class created under. 
    /// 
    /// Positon
    /// id
    /// name
    /// age
    /// 
    /// methods:
    /// ToString()
    /// </summary>
    public abstract class Animal
    {
        protected Position pos = new Position();
        protected int id;
        protected string name;
        protected double age;

        protected static int speed = 5;

        //properties
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public double Age
        {
            get { return age; }

            set
            {
                age = value;
            }
        }

        public Position Pos
        {
            get
            {
                return pos;
            }

            set
            {; }
        }

        public Animal()
        {
        }


        /// <summary>
        /// 3 arg constructor, position only
        /// </summary>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        public Animal(double xpos, double ypos, double zpos)
        {
            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;
        }

        /// <summary>
        /// full constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        /// <param name="zpos"></param>
        public Animal(string name, double age, int id, double xpos, double ypos, double zpos)
        {
            this.age = age;
            this.id = id;
            this.name = name;

            pos.X = xpos;
            pos.Y = ypos;
            pos.Z = zpos;
        }



        /// <summary>
        /// passes the movement up to the Position class
        /// </summary>
        /// <param name="dx">change in x</param>
        /// <param name="dy">change in y</param>
        /// <param name="dz">change in z</param>
        public abstract void Move(double dx, double dy, double dz = 0);


        public override string ToString()
        {
            //checks to be sure position has been given a value
            if (pos == null)
                return "Name: " + name + " Age: " + age + " ID: " + id + "Position: " + " N/A";
            else
                return "Name: " + name + " Age: " + age + " ID: " + id + " Position: " + pos.ToString();
        }
    }
}

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
    /// speed
    /// 
    /// methods:
    /// ToString()
    /// </summary>
    public abstract class Animal : IComparable
    {
        
        
        public readonly int maxStartXY = 20;  //maximum starting position as per assignment guidelines
        public readonly int maxHeightZ = 0;


        protected Position pos = new();
        protected int id;
        protected string name;
        protected double age;

        /// <summary>
        /// Compares animals by name
        /// Reference: https://docs.microsoft.com/en-us/dotnet/api/system.icomparable.compareto?view=net-5.0 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Animal otherAnimal = obj as Animal;
            if (otherAnimal.name != null)
                return this.name.CompareTo(otherAnimal.name);
            else
                throw new ArgumentException("Something messed up the in the animal comparrison!!!!!!!!!!!!!");
        }

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

        public int Speed
        {
            get { return speed; }
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
        /// full constructor using the static positon generator. if false, position will default to zero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="generatepos"></param>
        public Animal(string name, double age, int id, bool generatepos)
        {
            this.age = age;
            this.id = id;
            this.name = name;

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

        /// <summary>
        /// bird was eaten
        /// </summary>
        /// <param name="eatenBird"></param>
        public void Eat(Animal eatenAnimal)
        {
            Console.WriteLine("{0} is being eaten by {1}", eatenAnimal.Name, this.ToString());
        }

        /// <summary>
        /// passes the movement up to the Position class, default dz for non flying animals
        /// </summary>
        /// <param name="dx">change in x</param>
        /// <param name="dy">change in y</param>
        /// <param name="dz">change in z</param>
        public void Move(double dx, double dy, double dz = 0)
        {
            this.Pos.X += dx;
            this.Pos.Y += dy;
            this.Pos.Z += dz;
        }

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

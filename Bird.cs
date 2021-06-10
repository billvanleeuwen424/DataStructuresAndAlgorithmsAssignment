using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Bird : Animal
    {
        public new readonly int maxStartXY = 100;  //maximum starting position as per assignment guidelines
        public new readonly int maxHeightZ = 10;

        private readonly int speed = 10;
        private readonly int zspeed = 2;

        public override int Speed
        {
            get { return speed; }
        }

        public override int MaxStartXY
        {
            get { return maxStartXY; }
        }
        public override int MaxHeightZ
        {
            get { return maxHeightZ; }
        }

        public Bird()
        {
            
        }
        /// <summary>
        /// full constructor using the static positon generator. if false, position will default to zero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="id"></param>
        /// <param name="generatepos"></param>
        public Bird(string name, double age, int id, bool generatepos)
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
        /// a random generator move for birds only
        /// </summary>
        public void Move()
        {
            Random rand = new Random();

            double dx = ((rand.NextDouble() * 2 - 1) * rand.Next(0, speed));
            double dy = ((rand.NextDouble() * 2 - 1) * rand.Next(0, speed));
            double dz = ((rand.NextDouble() * 2 - 1) * rand.Next(0, zspeed));

            Pos.X += dx;
            Pos.Y += dy;
            Pos.Z += dz;
        }
    }
}

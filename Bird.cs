using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Bird : Animal
    {


        private new int speed = 10;


        /// <summary>
        /// move method for bird
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="dz"></param>
        public override void Move(double dx, double dy, double dz)
        {
            pos.Move(dx, dy, dz);
        }

    }
}

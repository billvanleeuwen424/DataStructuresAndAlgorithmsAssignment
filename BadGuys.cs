using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// only used for snakes and cats, made this to provide an Eat method to both.
    /// 
    /// </summary>
    public abstract class BadGuys : Animal
    {

        /// <summary>
        /// bird was eaten
        /// </summary>
        /// <param name="eatenBird"></param>
        public void Eat(Bird eatenBird)
        {
            Console.WriteLine("{0} was eaten by {1}", eatenBird.Name, this.Name);
            eatenBird = null;
        }
    }
}

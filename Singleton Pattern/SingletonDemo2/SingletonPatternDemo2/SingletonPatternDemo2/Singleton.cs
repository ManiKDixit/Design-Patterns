using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternDemo2
{
    public sealed class Singleton
    {
        /*
         * Sealed restricts the inheritance
         */
        private static int counter = 0;
        private static Singleton _instance = null;
        /*
         * For Eager loading write - 
         * private static readonly Singleton _instance = new Singleton();
         * 
         * To convert Eager to Lazy - 
         * private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>();
         * 
         */



        private static readonly object obj = new object();

        /*
         * Private constructor ensures that object is not 
         * instantiated other than within the class itself
         */

        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value" + counter.ToString());
        }

        /*
         * Public property is used to return only one instance of the class
         * leveraging on the private property 
         */

        public static Singleton GetInstance()
        {
            /*
             * Here we're implementing Double Check Locking to avoid unecessary use of lock as it's expensive
             */
            if(_instance == null)
            {
                lock (obj) //With the help of this only one thread can enter this code block at a given point of time
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton(); //This is Lazy initialization , it only works in single threaded environment
                    }
                }
            }

            /*
         * For Eager loading write - 
         * - Remove all the if statements and checks and just return the instance , it will take care of multiple threads too
         * return _instance ;
         * 
         * To convert Eager to Lazy - 
         * return _instance.Value;
         */


            return _instance;

        }


        /*
         * Public method which can be invoked through singleton instance
         */

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

       
    }
}

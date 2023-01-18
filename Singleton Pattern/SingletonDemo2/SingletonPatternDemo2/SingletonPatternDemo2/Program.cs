using SingletonPatternDemo2;
using System;

namespace SingleDemo
{

    class Program
    {
        static void Main(string[] args)
        {
            // This invokes the methods as actions
            //Here we're invoking the 2 mothods parallely 

            Parallel.Invoke(
                ()=>PrintStudentDetails(),
                ()=>PrintEmployeeDetails()
                ); 


            Console.ReadLine();

        }

        private static void PrintEmployeeDetails()
        {
            /*
            * Assuming Singleton is created from the Employee class
            * we refer to the GetInstance property from the Singleton class
            */

            Singleton MessageFromEmployee = Singleton.GetInstance();
            MessageFromEmployee.PrintDetails("This message is from Employee ");
        }

        private static void PrintStudentDetails()
        {
            /*
             * Assuming Singleton is created from the Student class
             * we refer to the GetInstance property from the Singleton class
             */
            Singleton MessageFromStudent = Singleton.GetInstance();
            MessageFromStudent.PrintDetails("This message is from Student");
        }
    }
}
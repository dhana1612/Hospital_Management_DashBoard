using Hospital_Management_DashBoard;
using System;

namespace HMS
{
    class HMS
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\tWelcome To Abc Dashboard");
            Console.WriteLine("\t------------------------");

            Operation_Class oc = new Operation_Class();
            oc.operation_Class();
        }
    }
}
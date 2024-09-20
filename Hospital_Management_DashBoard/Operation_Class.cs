using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_DashBoard
{
    internal class Operation_Class
    {

        public void operation_Class() {

            while (true)
            {
                Console.WriteLine("\nHospital Management System");
                Console.WriteLine("----------------------------");
                Console.WriteLine("\t1. Add Patient");
                Console.WriteLine("\t2. View Patients");
                Console.WriteLine("\t3. Update Patient");
                Console.WriteLine("\t4. Delete Patient");
                Console.WriteLine("\t5. Exit");
                Console.Write("\nChoose an option: ");
                var choice = Console.ReadLine();
                Dao d = new Dao();

                switch (choice)
                {
                    case "1":
                        d.AddPatient();
                        break;
                    case "2":
                        d.ViewPatient();
                        break;
                    case "3":
                        d.UpdatePatient();
                        break;
                    case "4":
                        d.DeletePatient();
                        break;
                    case "5":
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        Console.WriteLine("\nInvalid option! Please try again.");
                        break;
                }
            }
        }
    }
    
}

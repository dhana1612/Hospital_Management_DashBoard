using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Hospital_Management_DashBoard
{
    public class Dao
    {
        private int id;
        private string name;
        private int age;
        private string illness;
        SqlConnection con;

        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
        
        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }
        
        public int Age
        {
            get => age;
            set
            {
                age = value;
            }
        }

        public string Illness
        {
            get => illness;
            set
            {
                illness = value;
            }
        }

      


        public void OpenConnection()
        {
            try
            {
                string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Morning Shift\source\repos\Hospital_Management_DashBoard\Hospital_Management_DashBoard\Database1.mdf"";Integrated Security=True";
                con = new SqlConnection(s);
                con.Open();
               
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
        public void AddPatient()
        {
            while (true)
            {
                Console.Write("\nEnter Patient ID: ");
                id = Convert.ToInt32(Console.ReadLine());


                bool condition = Check(id);

                if (condition)
                {
                    Console.Write("\nEnter Patient name: ");
                    name = Console.ReadLine();

                    Console.Write("\nEnter Patient age: ");
                    age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nIllness: ");
                    illness = Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tPatient ID is Already Exist");
                }

            }


            OpenConnection(); 

            string query = "INSERT INTO  Details(Patient_ID,Patient_Name,Patient_Age,Illness) VALUES(" + id + ", '" + name + "' , " + age + "  , '" + illness + "' )";

            SqlCommand ins = new SqlCommand(query, con);


            try
            {
                ins.ExecuteNonQuery();
                Console.WriteLine("\nPatient Added Successfully.");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    

        public void ViewPatient()
        {
            string display = "SELECT * FROM Details";
            OpenConnection();

            SqlCommand view = new SqlCommand(display, con);

            SqlDataReader rdr = view.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("\nID: " + rdr.GetValue(0));
                    Console.WriteLine("Name: " + rdr.GetValue(1));
                    Console.WriteLine("Age: " + rdr.GetValue(2));
                    Console.WriteLine("Illness: " + rdr.GetValue(3) + "\n");
                }
            }
            else
            {
                Console.WriteLine("\nDatabase is Empty");
            }

        }


        public void UpdatePatient()
        {
            int update_Details;
            string uname;
            int uage;
            string uillness;

            while (true)
            {
                Console.Write("\nEnter the id that you want to update the patient details: ");
                 update_Details = Convert.ToInt32(Console.ReadLine());

                bool condition = Check(update_Details);

                if (condition)
                {
                    Console.WriteLine("\nNo Patient Record Found");
                }
                else
                {

                    Console.Write("\nEnter Patient name: ");
                    uname = Console.ReadLine();


                    Console.Write("\nEnter Patient age: ");
                    uage = Convert.ToInt32(Console.ReadLine());


                    Console.Write("\nIllness: ");
                    uillness = Console.ReadLine();
                    break;
                }

            }

            string updateQuery = "UPDATE Details SET Patient_Name = '" + uname + "' , Patient_Age = '" + uage + "' ,Illness = '" + uillness + "' WHERE Patient_ID = '" + update_Details + "'";


            OpenConnection();

            SqlCommand update = new SqlCommand(updateQuery, con);



            //Execute the update command
            int rowsAffected = update.ExecuteNonQuery();

            // Check if the update was successful
            if (rowsAffected > 0)
            {
                Console.WriteLine("\nData updated successfully.");
            }
            else
            {
                Console.WriteLine("\nNo records were updated.");
            }
        }


        public void DeletePatient()
        {
            int delete_ID;
            while (true)
            {
                Console.Write("\nEnter the Patient ID that you want to Delete: ");
                 delete_ID = Convert.ToInt32(Console.ReadLine());


                bool condition = Check(delete_ID);

                if (condition)
                {
                   Console.WriteLine("\nNo Patient Record Found");
                }
                else
                {
                    break;
                }

            }


            string Delete = "DELETE Details WHERE Patient_ID = '" + delete_ID + "'";

            OpenConnection();
            SqlCommand del = new SqlCommand(Delete, con);
            del.ExecuteNonQuery();
            Console.WriteLine("\nDeleted Successfully");
        }
   
    
        public bool Check(int id)
        {
            bool condition = false;

            string display = "SELECT Patient_ID FROM Details where Patient_ID = '"+id+"' ";
            OpenConnection();

            SqlCommand view = new SqlCommand(display, con);

            SqlDataReader rdr = view.ExecuteReader();

            int result = 0;


            while (rdr.Read())
            {
                result = (int)rdr.GetValue(0);
            }
            

            if(result == 0)
            {
                condition = true;
            }

            return condition;
        }
    
    }
}


























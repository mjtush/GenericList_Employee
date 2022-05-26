using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList_Employee
{
  class Employee
  {
		private string mName;
		private int mSalary;

		public string MName { get => mName; set => mName = value; }
		public int MSalary { get => mSalary; set => mSalary = value; }

		public Employee(string name, int salary)
    {
      mName = name;
      mSalary = salary;
    }
  }


  class Program
  {
    static void Main(string[] args) 
    {
      // Create a new empty List for Employee objects 
      // 10 is a capacity specification. Using capacity can improve performance, especiall when there are a lot of items.
      List<Employee> empList = new List<Employee>(10);

      // Add some records to the list
      empList.Add(new Employee("John Doe", 50000));
      empList.Add(new Employee("Jane Smith", 60000));
      empList.Add(new Employee("Nick Slick", 55000));
      empList.Add(new Employee("Mildred Mintz", 70000));

      // Inspect some List properties
      Console.WriteLine("empList Capacity is: {0}", empList.Capacity);
      Console.WriteLine("empList Count is: {0}", empList.Count);

      // Use Exists() and Find()
      if (empList.Exists(HighPay))
      {
        Console.WriteLine("\nHighly Paid Employee Found!\n");
      }

      Employee e = empList.Find(x => x.MName.StartsWith("J"));
      if (e != null)
      {
        Console.WriteLine("Found employee whose name starts with J: {0}", e.MName);
      }


      Console.WriteLine("\nPress Enter key to continue...");
            Console.ReadLine();
    }

    // delegate function to use for the Exists method
    static bool HighPay(Employee emp)
    {
      return emp.MSalary >= 65000;
    }
  }
}

using System;
using System.Collections.Generic;

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

  class EmployeeComparer : IComparer<Employee>
  {
    public int Compare(Employee x, Employee y)
    {
      if (x.MSalary > y.MSalary)
        return 1;
      if (x.MSalary == y.MSalary)
        return 0;
      else
        return -1;
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

      // Use ForEach to iterate over each item
      empList.ForEach(TotalSalaries);
      Console.WriteLine("Total payroll is: {0}\n", total);

      // Sort the list using a custom class
      // that implements the IComparer interface
      EmployeeComparer ec = new EmployeeComparer();
      empList.Sort(ec);
      foreach (Employee emp in empList)
      {
        Console.WriteLine("Salary for {0} is {1}", emp.MName, emp.MSalary);
      }

      Console.WriteLine("\nPress Enter key to continue...");
            Console.ReadLine();
    }

    // Iterator function for the ForEach method
    static int total = 0;
    static void TotalSalaries(Employee e)
    {
      total += e.MSalary;
    }

    // delegate function to use for the Exists method
    static bool HighPay(Employee emp)
    {
      return emp.MSalary >= 65000;
    }
  }
}

using System;
using System.Collections.Generic;

public class AttendanceManager
{
    public List<Employee> Employees = new List<Employee>();
    private int employeeId = 1;

    public void AddEmployee()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();
        Console.Write("Enter basic salary: ");
        double salary = double.Parse(Console.ReadLine());

        Employees.Add(new Employee
        {
            Id = employeeId++,
            Name = name,
            BasicSalary = salary,
            PresentDays = 0,
            AbsentDays = 0
        });

        Console.WriteLine("Employee added successfully.");
    }

    public void MarkAttendance()
    {
        foreach (var emp in Employees)
        {
            Console.Write($"Is {emp.Name} present today? (y/n): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
                emp.PresentDays++;
            else
                emp.AbsentDays++;
        }
    }

    public void DisplayEmployees()
    {
        Console.WriteLine("\nID\tName\tSalary\tPresent\tAbsent");
        foreach (var emp in Employees)
        {
            Console.WriteLine($"{emp.Id}\t{emp.Name}\t{emp.BasicSalary}\t{emp.PresentDays}\t{emp.AbsentDays}");
        }
    }
}


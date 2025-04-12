
using System;

class Program
{
    static void Main(string[] args)
    {
        AttendanceManager attendanceManager = new AttendanceManager();
        SalaryManager salaryManager = new SalaryManager(attendanceManager);

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n--- Employee Attendance & Salary Calculator ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Mark Attendance");
            Console.WriteLine("3. View Employees");
            Console.WriteLine("4. Calculate Salaries");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1": attendanceManager.AddEmployee(); break;
                case "2": attendanceManager.MarkAttendance(); break;
                case "3": attendanceManager.DisplayEmployees(); break;
                case "4": salaryManager.CalculateSalaries(); break;
                case "5": exit = true; break;
                default: Console.WriteLine("Invalid option. Try again."); break;
            }
        }
    }
}

// Employee.cs
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double BasicSalary { get; set; }
    public int PresentDays { get; set; }
    public int AbsentDays { get; set; }
}

// AttendanceManager.cs
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

// SalaryManager.cs
using System;

public class SalaryManager
{
    private AttendanceManager _attendanceManager;

    public SalaryManager(AttendanceManager manager)
    {
        _attendanceManager = manager;
    }

    public void CalculateSalaries()
    {
        Console.WriteLine("\n--- Salary Report ---");
        foreach (var emp in _attendanceManager.Employees)
        {
            double perDaySalary = emp.BasicSalary / 30;
            double totalSalary = perDaySalary * emp.PresentDays;
            Console.WriteLine($"{emp.Name} - Days Present: {emp.PresentDays}, Salary: Rs. {totalSalary:F2}");
        }
    }
}

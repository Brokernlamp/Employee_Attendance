
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



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

using System;


class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, decimal salary)
    {
        Name = name;
        Salary = salary;
    }
}
class EmployeeRegister
{
    private List<Employee> Employees = new List<Employee>();

    public void AddEmployee(string name, decimal salary)
    {
        Employee employee = new Employee(name, salary);
        Employees.Add(employee);
    }


    public void DisplayEmployees()
    {
        Console.WriteLine("Employee List:");
        foreach (var employee in Employees)
        {
            Console.WriteLine($"Name: {employee.Name}, Salary: {employee.Salary}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeRegister eRegister = new EmployeeRegister();


        while (true)
        {
            Console.WriteLine("Enter employee name (or 'exit' to stop): ");
            string name = Console.ReadLine();
            

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Error: Name cannot be empty. Please try again.");
                continue;
            }

            if (name.ToLower() == "exit") break;


            decimal salary = 0;
            bool validSalary = false;

            
            while (!validSalary)
            {
                Console.WriteLine("Enter employee salary: ");
       
                
                if (decimal.TryParse(Console.ReadLine(), out salary) && salary > 0)
                {
                    validSalary = true;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid positive decimal number for salary.");
                }
            }

            eRegister.AddEmployee(name, salary);
        }

        eRegister.DisplayEmployees();
    }
}
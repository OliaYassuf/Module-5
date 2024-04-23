using System;
using ConsoleApp5;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Employee
    {
        private string fullName;
        private DateTime dateOfBirth;
        private string phoneNumber;
        private string email;
        private string position;
        private string jobDescription;
        private decimal salary;

        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string JobDescription { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
        }

        public Employee(string fullName, DateTime dateOfBirth, string phoneNumber, string email, string position, string jobDescription, decimal salary)
        {
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            Position = position;
            JobDescription = jobDescription;
            Salary = salary;
        }

        public void InputData()
        {
            Console.WriteLine("Enter full name:");
            fullName = Console.ReadLine();

            Console.WriteLine("Enter date of birth (YYYY-MM-DD):");
            dateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter phone number:");
            phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter email:");
            email = Console.ReadLine();

            Console.WriteLine("Enter position:");
            position = Console.ReadLine();

            Console.WriteLine("Enter job description:");
            jobDescription = Console.ReadLine();

            Console.WriteLine("Enter salary:");
            Salary = decimal.Parse(Console.ReadLine());
        }

        public void DisplayData()
        {
            Console.WriteLine($"Full Name: {FullName}");
            Console.WriteLine($"Date of Birth: {DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Job Description: {JobDescription}");
            Console.WriteLine($"Salary: {Salary}");
        }

        public static Employee operator +(Employee emp, decimal amount)
        {
            emp.Salary += amount;
            return emp;
        }

        public static Employee operator -(Employee emp, decimal amount)
        {
            emp.Salary -= amount;
            return emp;
        }

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            return emp1.Salary == emp2.Salary;
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        public static bool operator <(Employee emp1, Employee emp2)
        {
            return emp1.Salary < emp2.Salary;
        }

        public static bool operator >(Employee emp1, Employee emp2)
        {
            return emp1.Salary > emp2.Salary;
        }
    }

    class Journal
    {
        public string Name { get; set; }
        public int FoundingYear { get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public Employee ChiefEditor { get; set; } // Нове поле для головного редактора журналу
        public int EmployeeCount { get; set; }

        public Journal(string name, int foundingYear, string description, string contactPhone, string email, Employee chiefEditor, int employeeCount)
        {
            Name = name;
            FoundingYear = foundingYear;
            Description = description;
            ContactPhone = contactPhone;
            Email = email;
            ChiefEditor = chiefEditor;
            EmployeeCount = employeeCount;
        }

        public void DisplayData()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Founding Year: {FoundingYear}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Contact Phone: {ContactPhone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Chief Editor:");
            ChiefEditor.DisplayData();
            Console.WriteLine($"Employee Count: {EmployeeCount}");
        }

        public static Journal operator +(Journal journal, int count)
        {
            journal.EmployeeCount += count;
            return journal;
        }

        public static Journal operator -(Journal journal, int count)
        {
            journal.EmployeeCount -= count;
            return journal;
        }

        public static bool operator ==(Journal journal1, Journal journal2)
        {
            return journal1.EmployeeCount == journal2.EmployeeCount;
        }

        public static bool operator !=(Journal journal1, Journal journal2)
        {
            return journal1.EmployeeCount != journal2.EmployeeCount;
        }

        public static bool operator <(Journal journal1, Journal journal2)
        {
            return journal1.EmployeeCount < journal2.EmployeeCount;
        }

        public static bool operator >(Journal journal1, Journal journal2)
        {
            return journal1.EmployeeCount > journal2.EmployeeCount;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Journal journal = (Journal)obj;
            return EmployeeCount == journal.EmployeeCount;
        }

        public override int GetHashCode()
        {
            return EmployeeCount.GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
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

        class Matrix
        {
            private int[,] data;

            public int Rows => data.GetLength(0);
            public int Columns => data.GetLength(1);

            public int this[int i, int j]
            {
                get { return data[i, j]; }
                set { data[i, j] = value; }
            }

            public Matrix(int rows, int columns)
            {
                data = new int[rows, columns];
            }

            public void InputData()
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        Console.WriteLine($"Enter element at position [{i + 1},{j + 1}]:");
                        data[i, j] = int.Parse(Console.ReadLine());
                    }
                }
            }

            public void DisplayData()
            {
                Console.WriteLine("Matrix:");

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        Console.Write(data[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            public int CalculateMaximum()
            {
                int max = data[0, 0];

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j] > max)
                        {
                            max = data[i, j];
                        }
                    }
                }

                return max;
            }

            public int CalculateMinimum()
            {
                int min = data[0, 0];

                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j] < min)
                        {
                            min = data[i, j];
                        }
                    }
                }

                return min;
            }

            public static Matrix operator +(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                {
                    throw new InvalidOperationException("Matrices must have the same dimensions for addition.");
                }

                Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }

                return result;
            }

            public static Matrix operator -(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                {
                    throw new InvalidOperationException("Matrices must have the same dimensions for subtraction.");
                }

                Matrix result = new Matrix(matrix1.Rows, matrix1.Columns);

                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        result[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }

                return result;
            }

            public static Matrix operator *(Matrix matrix, int scalar)
            {
                Matrix result = new Matrix(matrix.Rows, matrix.Columns);

                for (int i = 0; i < matrix.Rows; i++)
                {
                    for (int j = 0; j < matrix.Columns; j++)
                    {
                        result[i, j] = matrix[i, j] * scalar;
                    }
                }

                return result;
            }

            public static Matrix operator *(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.Columns != matrix2.Rows)
                {
                    throw new InvalidOperationException("Number of columns in the first matrix must be equal to the number of rows in the second matrix for multiplication.");
                }

                Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

                for (int i = 0; i < result.Rows; i++)
                {
                    for (int j = 0; j < result.Columns; j++)
                    {
                        for (int k = 0; k < matrix1.Columns; k++)
                        {
                            result[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }

                return result;
            }

            public static bool operator ==(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                    return false;

                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        if (matrix1[i, j] != matrix2[i, j])
                            return false;
                    }
                }

                return true;
            }

            public static bool operator !=(Matrix matrix1, Matrix matrix2)
            {
                return !(matrix1 == matrix2);
            }
        }

        class City
        {
            private string cityName;
            private string countryName;
            private int population;
            private string phoneCode;
            private string[] districts;

            public string CityName { get; set; }
            public string CountryName { get; set; }
            public int Population { get; set; }
            public string PhoneCode { get; set; }
            public string[] Districts { get; set; }

            public City()
            {
            }

            public City(string cityName, string countryName, int population, string phoneCode, string[] districts)
            {
                CityName = cityName;
                CountryName = countryName;
                Population = population;
                PhoneCode = phoneCode;
                Districts = districts;
            }

            public static City operator +(City city, int populationIncrease)
            {
                city.Population += populationIncrease;
                return city;
            }

            public static City operator -(City city, int populationDecrease)
            {
                if (city.Population < populationDecrease)
                {
                    throw new InvalidOperationException("Population cannot be decreased beyond 0.");
                }

                city.Population -= populationDecrease;
                return city;
            }

            public static bool operator ==(City city1, City city2)
            {
                return city1.Population == city2.Population;
            }

            public static bool operator !=(City city1, City city2)
            {
                return !(city1 == city2);
            }

            public static bool operator >(City city1, City city2)
            {
                return city1.Population > city2.Population;
            }

            public static bool operator <(City city1, City city2)
            {
                return city1.Population < city2.Population;
            }

            public void InputData()
            {
                Console.WriteLine("Enter city name:");
                CityName = Console.ReadLine();

                Console.WriteLine("Enter country name:");
                CountryName = Console.ReadLine();

                Console.WriteLine("Enter population:");
                Population = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter phone code:");
                PhoneCode = Console.ReadLine();

                Console.WriteLine("Enter number of districts:");
                int numDistricts = int.Parse(Console.ReadLine());
                Districts = new string[numDistricts];
                Console.WriteLine("Enter district names:");
                for (int i = 0; i < numDistricts; i++)
                {
                    Console.Write($"District {i + 1}: ");
                    Districts[i] = Console.ReadLine();
                }
            }

            public void DisplayData()
            {
                Console.WriteLine($"City Name: {CityName}");
                Console.WriteLine($"Country Name: {CountryName}");
                Console.WriteLine($"Population: {Population}");
                Console.WriteLine($"Phone Code: {PhoneCode}");
                Console.WriteLine("Districts:");
                foreach (var district in Districts)
                {
                    Console.WriteLine(district);
                }
            }
        }

        class CreditCard
        {
            private string cardNumber;
            private string cardholderName;
            private int cvc;
            private DateTime expiryDate;
            private double balance;

            public string CardNumber { get; set; }
            public string CardholderName { get; set; }
            public int CVC
            {
                get { return cvc; }
                set
                {
                    if (value.ToString().Length != 3)
                    {
                        throw new ArgumentException("CVC code must be a 3-digit number.");
                    }
                    cvc = value;
                }
            }
            public DateTime ExpiryDate { get; set; }
            public double Balance
            {
                get { return balance; }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Balance cannot be negative.");
                    }
                    balance = value;
                }
            }

            public CreditCard()
            {
            }

            public CreditCard(string cardNumber, string cardholderName, int cvc, DateTime expiryDate, double balance)
            {
                CardNumber = cardNumber;
                CardholderName = cardholderName;
                CVC = cvc;
                ExpiryDate = expiryDate;
                Balance = balance;
            }

            public static CreditCard operator +(CreditCard card, double amount)
            {
                card.Balance += amount;
                return card;
            }

            public static CreditCard operator -(CreditCard card, double amount)
            {
                if (card.Balance < amount)
                {
                    throw new InvalidOperationException("Insufficient funds.");
                }
                card.Balance -= amount;
                return card;
            }

            public static bool operator ==(CreditCard card1, CreditCard card2)
            {
                return card1.CVC == card2.CVC;
            }

            public static bool operator !=(CreditCard card1, CreditCard card2)
            {
                return !(card1 == card2);
            }

            public static bool operator >(CreditCard card1, CreditCard card2)
            {
                return card1.Balance > card2.Balance;
            }

            public static bool operator <(CreditCard card1, CreditCard card2)
            {
                return card1.Balance < card2.Balance;
            }

            public void DisplayData()
            {
                Console.WriteLine($"Card Number: {CardNumber}");
                Console.WriteLine($"Cardholder Name: {CardholderName}");
                Console.WriteLine($"CVC: {CVC}");
                Console.WriteLine($"Expiry Date: {ExpiryDate:MM/yyyy}");
                Console.WriteLine($"Balance: {Balance:C2}");
            }
        }

        static void Main(string[] args)
        {
            //1
            Employee emp1 = new Employee("Olia Yassuf", new DateTime(2005, 04, 16), "+49-175-28-70-153", "yassufo@gmail.com", "Manager", "Managing the team", 5000);
            Employee emp2 = new Employee("Darion Jobs", new DateTime(2000, 12, 16), "+49-175-28-70-154", "jobsd@gmail.com", "Supervisor", "Supervising the department", 4500);

            Console.WriteLine("Initial data:");
            emp1.DisplayData();
            Console.WriteLine();
            emp2.DisplayData();
            Console.WriteLine();

            emp1 += 500;
            Console.WriteLine("Employee 1 salary increased by $500:");
            emp1.DisplayData();
            Console.WriteLine();

            emp2 -= 1000;
            Console.WriteLine("Employee 2 salary decreased by $1000:");
            emp2.DisplayData();
            Console.WriteLine();

            Console.WriteLine($"Are the salaries of Employee 1 and Employee 2 equal? {emp1 == emp2}");
            Console.WriteLine();

            Console.WriteLine($"Are the salaries of Employee 1 and Employee 2 not equal? {emp1 != emp2}");
            Console.WriteLine();

            Console.WriteLine($"Is the salary of Employee 1 less than the salary of Employee 2? {emp1 < emp2}");
            Console.WriteLine();

            Console.WriteLine($"Is the salary of Employee 1 greater than the salary of Employee 2? {emp1 > emp2}");
            Console.WriteLine();

            //2
            Matrix matrix1 = new Matrix(2, 2);
            Matrix matrix2 = new Matrix(2, 2);

            Console.WriteLine("Enter data for matrix 1:");
            matrix1.InputData();

            Console.WriteLine("\nEnter data for matrix 2:");
            matrix2.InputData();

            Console.WriteLine("\nMatrix 1:");
            matrix1.DisplayData();

            Console.WriteLine("\nMatrix 2:");
            matrix2.DisplayData();

            Console.WriteLine("\nTesting operators:");

            Matrix sum = matrix1 + matrix2;
            Console.WriteLine("\nMatrix1 + Matrix2:");
            sum.DisplayData();

            Matrix diff = matrix1 - matrix2;
            Console.WriteLine("\nMatrix1 - Matrix2:");
            diff.DisplayData();

            int scalar = 2;
            Matrix productScalar = matrix1 * scalar;
            Console.WriteLine($"\nMatrix1 * {scalar}:");
            productScalar.DisplayData();

            Matrix productMatrix = matrix1 * matrix2;
            Console.WriteLine("\nMatrix1 * Matrix2:");
            productMatrix.DisplayData();

            Console.WriteLine("\nMatrix1 == Matrix2: " + (matrix1 == matrix2));

            Console.WriteLine("Matrix1 != Matrix2: " + (matrix1 != matrix2));

            //3
            City city1 = new City("Braunschweig", "Germany", 250000, "+49", new string[] { "Innenstadt", "Heidberg-Melverode", "Stöckheim-Leiferde" });
            City city2 = new City("Hannover", "Germany", 540000, "+49", new string[] { "Mitte", "Vahrenwald-List", "Bothfeld-Vahrenheide" });

            Console.WriteLine("City 1:");
            city1.DisplayData();
            Console.WriteLine();

            Console.WriteLine("City 2:");
            city2.DisplayData();
            Console.WriteLine();

            Console.WriteLine("Testing operators:");

            City city1AfterIncrease = city1 + 20000;
            Console.WriteLine("\nCity 1 after population increase:");
            city1AfterIncrease.DisplayData();
            Console.WriteLine();

            City city2AfterDecrease = city2 - 20000;
            Console.WriteLine("\nCity 2 after population decrease:");
            city2AfterDecrease.DisplayData();
            Console.WriteLine();

            Console.WriteLine("City 1 population equals City 2 population: " + (city1 == city2));
            Console.WriteLine();

            Console.WriteLine("City 1 population does not equal City 2 population: " + (city1 != city2));
            Console.WriteLine();

            Console.WriteLine("City 1 has greater population than City 2: " + (city1 > city2));
            Console.WriteLine();

            Console.WriteLine("City 1 has smaller population than City 2: " + (city1 < city2));

            //4
            CreditCard card1 = new CreditCard("1234567890123456", "Olia Yassuf", 123, new DateTime(2025, 12, 31), 500);
            CreditCard card2 = new CreditCard("9876543210987654", "Darion Jobs", 456, new DateTime(2024, 10, 31), 1000);

            Console.WriteLine("Card 1:");
            card1.DisplayData();
            Console.WriteLine();

            Console.WriteLine("Card 2:");
            card2.DisplayData();
            Console.WriteLine();

            Console.WriteLine("Testing operators:");

            CreditCard card1AfterIncrease = card1 + 300;
            Console.WriteLine("\nCard 1 after increasing balance:");
            card1AfterIncrease.DisplayData();
            Console.WriteLine();

            CreditCard card2AfterDecrease = card2 - 600;
            Console.WriteLine("\nCard 2 after decreasing balance:");
            card2AfterDecrease.DisplayData();
            Console.WriteLine();

            Console.WriteLine("Card 1 CVC equals Card 2 CVC: " + (card1 == card2));
            Console.WriteLine();

            Console.WriteLine("Card 1 CVC does not equal Card 2 CVC: " + (card1 != card2));
            Console.WriteLine();

            Console.WriteLine("Card 1 has greater balance than Card 2: " + (card1 > card2));
            Console.WriteLine();

            Console.WriteLine("Card 1 has smaller balance than Card 2: " + (card1 < card2));
        }
    }
}

using ContractWorker.Entities;
using ContractWorker.Entities.Enums;
using System.Globalization;

namespace ContractWorker
{
    internal class Program
    {
        /* converter um enum p/ string
         * string txt = OrderStatus.PendingPayment.ToString();
         * Console.WriteLine(txt);
         *
         * converter uma string p/ enum
         * OrderStatus os = Enum.Parse<OrderStatus>("Delivered");
         * Console.WriteLine(os);
        */

        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Departament dept = new Departament(deptName);

            Console.WriteLine("");

            Console.WriteLine("Enter worker datas");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level: ");
            WorkerLevel wl = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Worker worker = new Worker(name, wl, baseSalary, dept);

            Console.WriteLine("");

            Console.Write("How many contracts to this worker: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data below");
                Console.Write("Date (DD/MM/YYYY): "); DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value Per Hour: ");
                double vph = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                
                Contracts contract = new Contracts(date, vph, hours);
                worker.AddContract(contract);
                
                Console.WriteLine("-----------------");
            }
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Departament.Name);
            Console.WriteLine("Income for: " + monthAndYear + ": " + worker.Income(year, month).ToString
                ("f2", CultureInfo.InvariantCulture));
        }
    }
}

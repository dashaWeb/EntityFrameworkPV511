using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _08_Loading_types
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyDb context = new CompanyDb();
            // Lazy Loading 

            /*var worker = context.Workers.First();*/
            /*foreach (var worker in context.Workers.ToList())
            {
                Console.WriteLine($"[{worker.Id}] - {worker.FullName}");
                Console.WriteLine($"\t {worker.Department.Name}  ({worker.Department.PhoneNumber})");
                Console.WriteLine($"\t {worker.Country.Name}");
                foreach (var item in worker.Projects)
                {
                    Console.WriteLine($"\t\t {item.Name} ({item.LaunchDate.ToShortDateString()})");
                }

                Console.WriteLine();
            }*/

            // Eager Loading

            /*var workerQuery = context.Workers
                .Include(nameof(Worker.Department))
                .Include(nameof(Worker.Country))
                .Include(nameof(Worker.Projects));

            foreach (var worker in workerQuery)
            {
                Console.WriteLine($"[{worker.Id}] - {worker.FullName}");
                Console.WriteLine($"\t {worker.Department.Name}  ({worker.Department.PhoneNumber})");
                Console.WriteLine($"\t {worker.Country?.Name}");
                foreach (var item in worker.Projects)
                {
                    Console.WriteLine($"\t\t {item.Name} ({item.LaunchDate.ToShortDateString()})");
                }

                Console.WriteLine();
            }*/

            // Explicit Loading
            var worker = context.Workers.First();
            Console.WriteLine($"[{worker.Id}] - {worker.FullName}");

            context.Entry(worker).Reference(nameof(Worker.Department)).Load();
            Console.WriteLine($"\t {worker.Department.Name}  ({worker.Department.PhoneNumber})");
            context.Entry(worker).Reference(nameof(Worker.Country)).Load();
            Console.WriteLine($"\t {worker.Country?.Name}");
            context.Entry(worker).Collection(nameof(Worker.Projects)).Load();
            foreach (var item in worker.Projects)
            {
                Console.WriteLine($"\t\t {item.Name} ({item.LaunchDate.ToShortDateString()})");
            }

            Console.WriteLine();

        }
    }
}

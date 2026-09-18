using System;
using System.Linq;

namespace _06_EF___intro
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyDb context = new CompanyDb();
            /*int? a = null;
            Nullable<int> b = null*/
            // add countries
            /*context.Countries.Add(new Country() { Name = "Ukraine" });
            context.Countries.Add(new Country() { Name = "USA" });
            context.Countries.Add(new Country() { Name = "Poland" });

            context.SaveChanges();*/

            // add department
            /*context.Departments.Add(new Department() { Name = "Management", PhoneNumber = "14-54-89" });
            context.Departments.Add(new Department() { Name = "Prorgamming", PhoneNumber = "74-85-96" });
            context.Departments.Add(new Department() { Name = "Design", PhoneNumber = "73-91-82" });
            context.SaveChanges();*/

            // add works
            /*var w1 = new Worker()
            {
                Name = "Oleg",
                Surname = "King",
                Salary = 1245,
                Address = "non address",
                Birthdate = new DateTime(2007, 02, 02),
                Country = context.Countries.FirstOrDefault(c => c.Name == "Ukraine"),
                Department = context.Departments.FirstOrDefault(d => d.Name == "Management")
            };
            var w2 = new Worker()
            {
                Name = "Emma",
                Surname = "Miller",
                Salary = 2000,
                Address = "non address",
                Birthdate = new DateTime(2000, 02, 02),
                Country = context.Countries.FirstOrDefault(c => c.Name == "Poland"),
                Department = context.Departments.FirstOrDefault(d => d.Name == "Design")
            };
            var w3 = new Worker()
            {
                Name = "Tomm",
                Surname = "Joe",
                Salary = 1245,
                Address = "non address",
                Birthdate = new DateTime(2001, 02, 02),
                Country = context.Countries.FirstOrDefault(c => c.Name == "USA"),
                Department = context.Departments.FirstOrDefault(d => d.Name == "Prorgamming")
            };*/

            // projects
            /* var p1 = new Project() { Name = "Tetris", LaunchDate = new DateTime(1982, 02, 02) };
             var p2 = new Project() { Name = "PacMan", LaunchDate = new DateTime(2003, 02, 02) };
             var p3 = new Project() { Name = "CS", LaunchDate = new DateTime(2012, 02, 02) };

             context.Projects.AddRange(new[] { p1, p2, p3 });
             context.Workers.AddRange(new[] { w1, w2, w3 });

             context.SaveChanges();

             w1.Projects.Add(p1);
             w1.Projects.Add(p2);

             w2.Projects.Add(p3);
             w2.Projects.Add(p2);

             w3.Projects.Add(p3);
             w3.Projects.Add(p1);

             context.SaveChanges();*/

            /*foreach (var c in context.Countries)
            {
                Console.WriteLine($"Id [{c.Id}] --> {c.Name}");
            }*/

            /*foreach (var w in context.Workers)
            {
                Console.WriteLine($"\n\n {new string('-',50)}");
                Console.WriteLine($"------------- Worker :: {w.Id} {w.Name} {w.Surname} \n Department : {w.DepartmentId} {w.Salary} \n Birthdate : {w.Birthdate?.ToShortDateString()}" );
                Console.WriteLine($" Country : {w.CountryId}");

                foreach (var item in w.Projects)
                {
                    Console.WriteLine($"Project {item.Name} from {item.LaunchDate.ToShortDateString()}");
                }
            }*/

            Worker worker = context.Workers.Find(1);
            if(worker == null)
            {
                Console.WriteLine("Worker not found");
                return;
            }

            // Load Reference
            context.Entry(worker).Reference(nameof(Worker.Department)).Load();
            Console.WriteLine($" ---- Worker [{worker.Id}] {worker.Name}");
            Console.WriteLine($"Department :: {worker.Department.Name}"); // department reference
            context.Entry(worker).Reference(nameof(Worker.Country)).Load();
            Console.WriteLine($"Country :: {worker.Country?.Name}");

            // Load Collection
            context.Entry(worker).Collection(nameof(Worker.Projects)).Load();
            foreach (var item in worker.Projects)
            {
                Console.WriteLine($"Project {item.Name} from {item.LaunchDate.ToShortDateString()}");
            }
        }
    }
}

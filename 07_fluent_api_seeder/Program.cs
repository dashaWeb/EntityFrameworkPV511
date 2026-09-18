using System;
using System.Linq;

namespace _07_fluent_api_seeder
{
    class Program
    {
        static void Main(string[] args)
        {
            AirplaneDb context = new AirplaneDb();
            foreach (var item in context.Clients.ToList())
            {
                Console.WriteLine($"[{item.Id}] {item.Name} {item.Email}");
            }

            context.Clients.Add(new Client() { Name = "Olia", Email = "olia.gmail.com" });
            context.SaveChanges();

            foreach (var item in context.Accounts.ToList())
            {
                Console.WriteLine($"{item.Login} \t {item.Password}");
            }
        }
    }
}

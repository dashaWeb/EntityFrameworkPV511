using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Data_access
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string conn = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            SportShopDb db = new SportShopDb(conn);
            //db.Create("dumbbells","equipment", 100, 50, "China", 150);

            /*db.Create(new Product()
            {
                Name = "Rackets",
                Type = "Equipment",
                Quantity = 50,
                CostPrice = 100,
                Producer = "China",
                Price = 250
            });*/

            List<Product> products = db.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id,-15}{item.Name, -20}{item.Price, 10}");
            }

            Product pr = db.GetOneProduct(1);
            if(pr == null)
                Console.WriteLine("Product not found");
            else
            {
                Console.WriteLine($"{pr.Id,-10}{pr.Name,-20} {pr.Quantity,-10}");
                pr.Quantity = 25;
                db.Update(pr);

            }

            db.Delete(1011);
            Console.WriteLine();
            foreach (var item in db.GetAll())
            {
                Console.WriteLine($"{item.Id,-15}{item.Name,-20}{item.Price,10}");
            }
        }
    }
}

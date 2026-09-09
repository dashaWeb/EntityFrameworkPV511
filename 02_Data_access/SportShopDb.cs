using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Data_access
{
    /*
       [C] - Create 
       [R] - Read 
       [U] - Update
       [D] - Delete
    */
    class SportShopDb
    {
        private SqlConnection connection;
        private string connectionString;

        public SportShopDb(string connectionString)
        {
            this.connectionString = connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Database is ready to work!");
        }

        public void Create(Product product)
        {
            string cmdText = $@"insert into Products
                                values(@name, @type, @quantity,
                                        @costPrice, @producer, @price)";
            SqlCommand cmd = new SqlCommand(cmdText, connection);

            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = "name",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = product.Name
            };
            cmd.Parameters.Add(parameter);

            cmd.Parameters.AddWithValue("type", product.Type);
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.Parameters.AddWithValue("costPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("producer", product.Producer);
            cmd.Parameters.AddWithValue("price", product.Price);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Product was added to database");

        }
        private List<Product> GetProductsByQuery(SqlDataReader reader)
        {
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6]
                });
            }
            reader.Close();
            return products;
        }
        public List<Product> GetAll()
        {
            string cmdText = @"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);

            var reader = command.ExecuteReader();
            return this.GetProductsByQuery(reader);
           
        }
        public Product GetOneProduct(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();

            return this.GetProductsByQuery(reader).FirstOrDefault();
        }
        public void Update(Product product)
        {
            string cmdText = $@" update Products 
                                set Name = @name,
                                TypeProduct = @type,
                                Quantity = @quantity,
                                CostPrice = @costPrice,
                                Producer = @producer,
                                Price = @price
                                where Id = {product.Id}";
            SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("name", product.Name);
            cmd.Parameters.AddWithValue("type", product.Type);
            cmd.Parameters.AddWithValue("quantity", product.Quantity);
            cmd.Parameters.AddWithValue("costPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("producer", product.Producer);
            cmd.Parameters.AddWithValue("price", product.Price);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Product was update to database");
        }
        public void Delete(int id)
        {
            string cmdText = $@"delete Products where Id = {id}";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Product was deleted from database");
        }

    }
}

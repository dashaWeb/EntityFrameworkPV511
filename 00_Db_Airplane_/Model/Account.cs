namespace _00_Db_Airplane_
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int? ClientId { get; set; }
        public Client Client { get; set; }
    }
}

namespace ASP_hometask1.Entity
{
    public class Flora
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public Flora(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
    }
}

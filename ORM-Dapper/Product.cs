namespace ORM_Dapper
{
    public class Product
    {
        public Product() { }

        public int ProductID { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public int CategoryID { get; set; }
    }
}

//string name, double price, int categoryID
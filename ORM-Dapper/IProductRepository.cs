namespace ORM_Dapper
{
    public interface IProductRepository
    {
        //this is an IEnumerable of Product type from our Product class we created
        //for a collection of Products
        IEnumerable<Product> GetAllProducts();

        //create a stub method b/c interface
        void CreateProduct(string name, double price, int categoryID);

        //create UpdateProduct method
        void UpdateProduct(int productID, string updatedName);

        void DeleteProduct(int productId);

    }
}

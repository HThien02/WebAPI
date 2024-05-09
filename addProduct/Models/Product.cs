namespace addProduct.Models
{
    public class Product
    {
        public string? productName { get; set; }
        public string? productPrice { get; set; }

    }

    public class ProductDetail : Product
    {
        public Guid? productID { get; set; }
    }
}

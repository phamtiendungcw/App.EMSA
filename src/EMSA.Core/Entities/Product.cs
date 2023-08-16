namespace EMSA.Core.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal ImportPrice { get; set; }
    }
}
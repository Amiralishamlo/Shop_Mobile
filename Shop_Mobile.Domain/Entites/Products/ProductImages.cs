using Shop_Mobile.Domain.Entites.Commons;

namespace Shop_Mobile.Domain.Entites.Products
{
    public class ProductImages : BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string Src { get; set; }
    }
}

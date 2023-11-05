using Shop_Mobile.Domain.Entites.Commons;

namespace Shop_Mobile.Domain.Entites.Products
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }

        public long? ParentCategoryId { get; set; }


        public virtual ICollection<Category> SubCategories { get; set; }
    }
}

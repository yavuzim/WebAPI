namespace WebAPI.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Category> Products { get; set; }
    }
}

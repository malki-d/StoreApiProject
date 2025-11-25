using ex01.Models;

namespace ex01.Dto
{
    public class ProductDto
    {
        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public string ImageUrl { get; set; } = null!;
        public string Desc { get; set; } = null!;
    }
    public class ProductWithCategoriesDto
    {
        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public string ImageUrl { get; set; } = null!;
        public string Desc { get; set; } = null!;

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    }
    public class CreateProductDto
    {

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string Desc { get; set; } = null!;

      public virtual ICollection<Category>? Categories { get; set; } = new List<Category>();

    }
    public class BagDto
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public virtual Product Product { get; set; } = null!;

    }
    public class CreateBagDto
    {

        public string ProductId { get; set; } 

        public string UserId { get; set; } 

    }
    public class UserDto
    {

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

    }


}

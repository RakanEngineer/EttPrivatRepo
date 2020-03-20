using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EttPrivatRepo.Data.Entities
{
    public class CategoryProduct
    {

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public CategoryProduct()
        {

        }
        public CategoryProduct(int categoryId, int productId)
        {
            CategoryId = categoryId;
            ProductId = productId;

        }

    }
}

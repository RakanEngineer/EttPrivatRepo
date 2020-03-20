using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EttPrivatRepo.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Uri ImageUrl { get; set; }
        public IList<CategoryProduct> CategoryProduct { get; set; } = new List<CategoryProduct>();
        public Product()
        {

        }
        //public Product(int id, string name, string description, int price, Uri imageUrl)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //    ImageUrl = imageUrl;
        //}

        public Product(string name, string description, int price, Uri imageUrl)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;

        }
    }
}

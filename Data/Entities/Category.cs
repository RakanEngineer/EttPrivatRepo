using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EttPrivatRepo.Data.Entities
{
    public class Category
    {
        public Category()
        {

        }
        public Category(string name, Uri imageurl)
        {
            Name = name;
            ImageUrl = imageurl;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        public IList<CategoryProduct> CategoryProduct { get; set; } = new List<CategoryProduct>();


    }
}

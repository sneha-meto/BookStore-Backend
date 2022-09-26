using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Category
    {
        public Category(int categoryId, string categoryName, string description, string image, bool status, int position, DateTime createdAt)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            Image = image;
            Status = status;
            Position = position;
            CreatedAt = createdAt;
        }

        public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public bool Status { get; set; }
		public int Position { get; set; }
		public DateTime CreatedAt { get; set; }


		
	}
}
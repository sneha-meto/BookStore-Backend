using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public class Book
    {
        public Book(int bookId, int categoryId, string title, string iSBN, int year, float price, string description, int position, bool status, string image, string author)
        {
            BookId = bookId;
            CategoryId = categoryId;
            Title = title;
            ISBN = iSBN;
            Year = year;
            Price = price;
            Description = description;
            Position = position;
            Status = status;
            Image = image;
            Author = author;
        }

        public Book() { }

        public int BookId { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public int Year { get; set; }
		public float Price { get; set; }
		public string Description { get; set; }
		public int Position { get; set; }
		public bool Status { get; set; }
		public string Image { get; set; }
		public string Author { get; set; }

	}
}
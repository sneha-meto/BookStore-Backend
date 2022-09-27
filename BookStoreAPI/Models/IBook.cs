﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAPI.Models
{
    public interface IBook
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(int id);


        List<Book> SearchBooks(string type, string key);


    }
}
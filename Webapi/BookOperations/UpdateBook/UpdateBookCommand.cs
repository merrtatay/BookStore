using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.Common;
using Webapi.DBOperations;
namespace Webapi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set;}
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand (BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;

        }

        public void Handle()
        {
            
            var book= _dbContext.Books.SingleOrDefault(x=> x.Id==BookId);
            if (book is null)
            throw new InvalidOperationException("bu ıd'ye ait bir kitap bulunmuyor");

            

            book.GenreId= Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount= Model.PageCount!= default ?   Model.PageCount : book.PageCount;
            book.Title= Model.Title != default ? Model.Title : book.Title;
                        _dbContext.SaveChanges();

        }






        public class UpdateBookModel
        {
            public string Title{ get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; } 
            public DateTime   PublishTime { get; set; }
        }
    }




}
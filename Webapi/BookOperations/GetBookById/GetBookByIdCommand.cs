using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.Common;
using Webapi.DBOperations;
namespace Webapi.BookOperations.GetBookById
{

    public class GetBookByIdCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public GetBookByIdCommand (BookStoreDbContext dbContext)
        {
            _dbContext= dbContext;
            

        }
        public BookDetailWievModel Handle()
        {
            var book=_dbContext.Books.Where(book=> book.Id==BookId).SingleOrDefault();
            if(book is null)
            throw new InvalidOperationException("Kitap bulunamadı");
            BookDetailWievModel vm = new BookDetailWievModel();
            vm.Title= book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishTime=book.PublishTime.Date.ToString("dd/MM/yyyy");
            return vm;
        }


    }
    public class BookDetailWievModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }

        public string PublishTime { get; set; }
    }
    

}
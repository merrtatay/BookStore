
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.BookOperations.GetBooks;
using Webapi.DBOperations;
using Webapi.BookOperations.CreateBook;
using static Webapi.BookOperations.CreateBook.CreateBookCommand;
using static Webapi.BookOperations.UpdateBook.UpdateBookCommand;
using Webapi.BookOperations.UpdateBook;
using Webapi.BookOperations.GetBookById;
using Webapi.BookOperations.DeleteBook;

namespace Webapi.AddControllers{
    [ApiController]
    [Route ("[Controller]s")]
    public class BookController : ControllerBase
    {
        
        private readonly BookStoreDbContext _context;
        public BookController (BookStoreDbContext context)
        {
            _context=context;
        }

        [HttpGet]
         public IActionResult GetBooks()
         {
             GetBooksQuery query = new GetBooksQuery(_context);
             var result =query.Handle();
               return Ok(result);
            
         }
         [HttpGet("{id}")]
         public IActionResult GetById(int id){

            BookDetailWievModel result;
            
            try
            {
               GetBookByIdCommand command = new GetBookByIdCommand(_context);
            command.BookId=id;
            result =command.Handle();
            }
            catch (Exception ex)
            {
               
               return BadRequest(ex.Message);
            }
            return Ok(result);

                                      
                   
         }
         [HttpPost]
         public IActionResult AddBook([FromBody] CreateBookModel newBook) 
         {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
               command.Model = newBook;
               command.Handle();
               
            }
            catch (Exception ex)
            {
               
               return  BadRequest(ex.Message); 
            }
            return Ok();
                       
         }
         [HttpPut("{id}")]
         public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updatedBook){

            
            try
            {
               UpdateBookCommand command = new UpdateBookCommand(_context);
               command.BookId=id;
               command.Model = updatedBook;
               command.Handle();
               
            }
            catch (Exception ex)
            {
               
               return  BadRequest(ex.Message);
            }
            return Ok();
            

         }
         [HttpDelete("{id}")]
         public IActionResult DeleteBook(int id)
         {
            try
            {
               DeleteBookCommand command =new DeleteBookCommand(_context);
               command.BookId=id;
               command.Handle();
               
            }
            catch (Exception ex)
            {
               
               return BadRequest(ex.Message);
            }
            return Ok();
           
         }






    }
}
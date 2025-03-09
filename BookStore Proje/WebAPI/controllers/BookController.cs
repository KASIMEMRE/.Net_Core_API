using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebAPI.BookOperations.CreateBooks;
using WebAPI.BookOperations.DeleteBook;
using WebAPI.BookOperations.GetBookDetailQuery;
using WebAPI.BookOperations.GetBooks;
using WebAPI.BookOperations.UpdateBook;
using WebAPI.DBOperations;
using FluentValidation.Results;
using static WebAPI.BookOperations.CreateBooks.CreateBookCommand;
using FluentValidation;




namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController :ControllerBase{
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]                                   
            public IActionResult GetBooks(){  
                GetBooksQuery query = new GetBooksQuery(_context,_mapper);
                var result = query.Handle();
                                
            
                return Ok(result);

        }  



        [HttpGet("{id}")]
            public IActionResult GetById(int id){     

                BookDetailViewModel result; 
               
                try
                {
                    GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                    GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                    validator.ValidateAndThrow(query);
                    query.BookId= id;
                    result = query.Handle();
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
             CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model=newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);

                // if (!result.IsValid)
                // foreach (var item in result.Errors)
                
                //     Console.WriteLine("Özellik "+item.PropertyName+"-Error Message :"+item.ErrorMessage);
                // else
                //       command.Handle();
                
              
              
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok();
        }




        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookCommand.updatedBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.BookId=id;
                command.Model=updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            return Ok();
        } 

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId=id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
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
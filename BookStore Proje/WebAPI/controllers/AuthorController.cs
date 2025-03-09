using System;
using WebAPI.DBOperations;
using FluentValidation.Results;
using static WebAPI.BookOperations.CreateBooks.CreateBookCommand;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAPI.Application.AuthorOperations.Queries.GetAuthor;
using WebAPI.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebAPI.Application.AuthorOperations.CreateAuthor;
using WebAPI.Application.AuthorOperations.UpdateAuthor;
using WebAPI.Application.AuthorOperations.DeleteAuthor;




namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController :ControllerBase{

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthors(){
            GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpGet("id")]
        public ActionResult GetAuthorDetail(int id){
            GetAuthorsQueryDetail query = new GetAuthorsQueryDetail(_context,_mapper);
            query.AuthorId = id;
            GetAuthorsQueryDetailValidator validator = new GetAuthorsQueryDetailValidator();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpPost]
        public ActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor){
            CreateAuthorCommand command = new CreateAuthorCommand(_context);
            command.Model=newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("id")]
        public ActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor){
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;
            command.Model = updateAuthor;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]

        public ActionResult DeleteAuthor(int id){
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


    }

}

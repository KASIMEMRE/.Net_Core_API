using System;
using WebAPI.DBOperations;
using FluentValidation.Results;
using static WebAPI.BookOperations.CreateBooks.CreateBookCommand;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.CreateGenre;
using WebAPI.Application.GenreOperations.UpdateGenre;
using WebAPI.Application.GenreOperations.DeleteGenre;




namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController :ControllerBase{

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenres(){
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpGet("id")]
        public ActionResult GetGenreDetail(int id){
            GetGenresQueryDetail query = new GetGenresQueryDetail(_context,_mapper);
            query.GenreId = id;
            GetGenresQueryDetailValidator validator = new GetGenresQueryDetailValidator();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }
        [HttpPost]
        public ActionResult AddGenre([FromBody] CreateGenreModel newGenre){
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model=newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("id")]
        public ActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre){
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = id;
            command.Model = updateGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]

        public ActionResult DeleteGenre(int id){
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = id;
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


    }

}

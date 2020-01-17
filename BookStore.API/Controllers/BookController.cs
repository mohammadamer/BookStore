using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.API.ViewModels;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;

        public BookController(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/books")]
        public IActionResult Get()
        {
            var books = _service.GetAll().ToList();

            return Ok(_mapper.Map<List<BookViewModel>>(books));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/books/{isbn}")]
        public IActionResult GetByIsbn(string isbn)
        {
            var book = _service.GetByIsbn(isbn);

            return Ok(_mapper.Map<BookViewModel>(book));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/books")]
        public IActionResult Post([FromBody] BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);
            if (book != null)
            {
                _service.Add(book);
                return Ok();
            }
            return BadRequest();

        }

        [HttpPut]
        [AllowAnonymous]
        [Route("v1/books/{id}")]
        public IActionResult Update([FromBody] BookViewModel bookViewModel)
        {
            var book = _mapper.Map<Book>(bookViewModel);
            if (book != null)
            {
                _service.Update(book);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("v1/books/{id}")]
        public IActionResult Delete(int id)
        {
            if (id != 0)
            {
                _service.Remove(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}
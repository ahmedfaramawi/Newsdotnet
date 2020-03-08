using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using News.Api.Models;
using News.Core.Entities;
using News.Shared.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace News.Api.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public NewsController(IRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<ArticleDTO>> GetAll(string orderbytitle , string orderbydate)
        {

            IEnumerable<Article> items;
            if (!string.IsNullOrEmpty(orderbytitle))
            {
                items = _repository.List<Article>().OrderByDescending(x => x.title);
            }
            else if (!string.IsNullOrEmpty( orderbydate ))
            {
                items = _repository.List<Article>().OrderByDescending(x => x.date);
            }
            else if (!string.IsNullOrEmpty(orderbytitle) && !string.IsNullOrEmpty(orderbydate ))
            {
                items = _repository.List<Article>().OrderByDescending(x => x.date).OrderByDescending(x => x.title);
            }
            else
            {
                items = _repository.List<Article>();
            }
            

            return Ok(_mapper.Map<List<ArticleDTO>>(items));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ArticleDTO Get(int id)
        {
            var result = _repository.GetById<Article>(id);
            return _mapper.Map<ArticleDTO>(result);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]ArticleDTO value)
        {
            _repository.Add(_mapper.Map<Article>(value));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ArticleDTO value)
        {
            _repository.Update<Article>(_mapper.Map<Article>(value));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var Articletodelete = _repository.GetById<Article>(id);
                _repository.Delete<Article>(Articletodelete);
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}

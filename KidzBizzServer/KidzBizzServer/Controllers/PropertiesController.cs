﻿using KidzBizzServer.BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KidzBizzServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        // GET: api/<PropertiesController>
        [HttpGet]
        public IEnumerable<Property> Get()
        {
            Property property = new Property();
            return property.Read();
          
        }

        // GET api/<PropertiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropertiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PropertiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditorAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuditorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditorProfileController : ControllerBase
    {
        // GET: api/<AuditProfileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuditProfileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuditProfileController>
        /// <summary>
        /// Register a 
        /// </summary>
        /// <param name="profileRequest"></param>
        [HttpPost]
        public void Post([FromBody] AuditorProfileCreationRequest profileRequest)
        {
            string todo = "createprofile";
        }

        // PUT api/<AuditProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuditProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

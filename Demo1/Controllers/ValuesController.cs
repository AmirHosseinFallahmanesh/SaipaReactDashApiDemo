using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            DemoContext context = new DemoContext();
            context.Providers.Add(new Provider()
            {
                Name = "fact1",
                ProviderId = 1
            });
            context.Providers.Add(new Provider()
            {
                Name = "fact2",
                ProviderId = 2
            });

            context.SaveChanges();
            context.EnParts.Add(new EnPart
            {
                Name = "پارت یک",
                EnPartId = 1,
                ProviderId = 1

            });
            context.EnParts.Add(new EnPart
            {
                Name = "پارت دو",
                EnPartId = 2,
                ProviderId = 2

            });
            context.SaveChanges();
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

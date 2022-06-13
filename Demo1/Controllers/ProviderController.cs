using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        DemoContext context = new DemoContext();
        public IActionResult GetAll()
        {
            return Ok(context.Providers.ToList());
        }

        [HttpDelete("{key}")]
        public void Delete(int key)
        {
            context.Providers.Remove(new Provider() { ProviderId = key });
            context.SaveChanges();
        }

        [HttpPost]
        public IActionResult Post(Provider provider)
        {
            context.Providers.Add(new Provider()
            {
                Name = provider.Name

            }
            );
            context.SaveChanges();
            return Created($"/provider","ok");
        }


        [HttpPut]
        public void Put( [FromBody] Provider Provider)
        {
            context.Providers.Update(Provider);
            context.SaveChanges();
        }
    }
}
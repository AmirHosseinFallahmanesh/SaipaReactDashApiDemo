using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnPartController : ControllerBase
    {
        DemoContext context = new DemoContext();
        public IActionResult GetAll()
        {
            return Ok(context.EnParts.Include(a=>a.Provider).ToList());
        }

    }
}
using ex01.Data;
using ex01.Dto;
using ex01.Models;
using ex01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ex01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagsController : ControllerBase
    {
        private readonly IBagService _service ;
        public BagsController(IBagService service)
        {
            _service = service;
        }

        //GetBags
        [HttpGet]
        public IActionResult GetBags()
        {
            return Ok(_service.GetBags());
        }

        //CreateBag
        [HttpPost]
        public IActionResult CreateBag([FromBody]CreateBagDto createBagDto)
        {
            return Ok(_service.CreateBag(createBagDto));

        }
    }
}

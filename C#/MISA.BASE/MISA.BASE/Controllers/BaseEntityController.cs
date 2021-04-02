using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Declare
        IBaseService<T> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            // validate id
            Guid.TryParse(id, out var idGuid);

            if(idGuid == Guid.Empty)
            {
                return BadRequest();
            }
            return Ok(_baseService.GetById(idGuid));
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}

using ASP_hometask1.Entity;
using ASP_hometask1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_hometask1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ManageController : Controller
    {
        private IActions _actions;

        public ManageController(IActions actions)
        {
            _actions = actions;
        }

        //get

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var get = _actions.Read(id);
            return Json(get);
        }

        //post

        [HttpPost]
        public  ActionResult<Flora> Post([FromBody] Flora flora)
        {
            if (flora == null)
            {
                return BadRequest();
            }

            _actions.Create(flora);
            return Ok(flora);
        }

        //put 
        [HttpPut]
        public void Put([FromBody] Flora flora)
        {
            _actions.Update(flora);
        }

        //delete
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            _actions.Delete(id);
        }
    }
}

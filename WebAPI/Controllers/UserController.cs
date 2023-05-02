using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using EntidadesNegocio;
using DTOs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUser _userBL;
        public UserController(IUser userBL)
        {
            _userBL=userBL; ;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserGetAllDTO>> Get()
        {
            return await _userBL.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

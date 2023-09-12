using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
        [HttpGet]
        public async Task<IActionResult> GetAync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsyn(User user)
        {
            if (user == null || String.IsNullOrEmpty(user.FirstName))
                return BadRequest();
            return Created("",user);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest();
            }
            
            return Ok();
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateUserAsync(string id,User user)
        {
            if (!ObjectId.TryParse(id, out _) || String.IsNullOrEmpty(user.FirstName))
            {
                return BadRequest();
            }

            return Ok();


        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            if (!ObjectId.TryParse(id, out _))
            {
                return BadRequest();
            }

            return Ok();


        }
    }
}

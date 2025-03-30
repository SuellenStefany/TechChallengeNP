using Microsoft.AspNetCore.Mvc;
using TechChallenge.Application.DTOs.UserForm;
using TechChallenge.Domain.Interfaces.IUserForm;

namespace TechChallenge.Presentation.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var user = await _userService.GetAll();
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateUserDto createUser)
        {
            var create = await _userService.CreateUser(createUser);
            if (create == null)
            {
                return BadRequest("Invalid Data");
            }
            return Ok(create);
        }
        [HttpPut("update/{Id}")]
        public async Task<IActionResult> Update(Guid Id, [FromBody] UpdateUserDto updateUser)
        {
            var existUser = await _userService.GetById(Id);
            if (existUser == null)
            {
                return NotFound("User not found.");
            }
            var upUser = await _userService.UpdateUser(Id, updateUser);
            return Ok(upUser);
        }
        [HttpDelete("delete/{Id}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var existUser = await _userService.GetById(Id);
            if (existUser == null)
            {
                return NotFound("User not found.");
            }
            await _userService.DeleteUser(Id);
            return Ok("Deleted");
        }
    }
}

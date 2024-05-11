namespace CoreReact.Controllers;
[Route(template: "[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public readonly IUserService userService;
    public UserController(IUserService userService) {this.userService = userService;}
    [HttpPost]
    public async Task<IActionResult> addUser(UserDTO user)
    {
        var _user = await userService.add(user);
        return Ok(_user);
    }
    [HttpGet]
    public async Task<IActionResult> getAll()
    {
        var users = await userService.getAll_dto();
        return Ok(users);
    }
    [HttpDelete]
    public async Task<IActionResult> delete(int id)
    {
        var user = await userService.getById(id);
        if(user == null) return BadRequest("Wrong Id !");
        userService.delete(user);
        return Ok("success");
    }
    [HttpPut]
    public async Task<IActionResult> update(int id , UserDTO userNew)
    {
        var user = await userService.getById(id);
        if(user == null) return BadRequest("Wrong Id !");
        var newUser = userService.mapManual(user,userNew);
        userService.update(newUser);
        return Ok(userNew);
    }
}
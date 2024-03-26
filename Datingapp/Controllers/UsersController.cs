using Datingapp.Data;
using Datingapp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Datingapp.Controllers;
 [Authorize]
public class UsersController : BaseApiController
{
   
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;

    }
  
    [HttpGet("{id}")] // Api/users/2
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {

        return await _context.Users.FindAsync(id);

    }


}

using System.Security.Cryptography;
using System.Text;
using Datingapp.Data;
using Datingapp.DTOs;
using Datingapp.Entities;
using Datingapp.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Datingapp.Controllers;

public class AccountController: BaseApiController

{
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;


    public AccountController(DataContext context, ITokenService TokenService)


    {
        _context = context;
        _tokenService = TokenService;


    }
    [HttpPost ("register")] //Post: api/account/register
    public async Task <ActionResult<UserDto>> Register([FromBody]RegisterDtos registerDtos)

    
    {
        if (await UserExists(registerDtos.Username))return BadRequest("UseaName is taken");



        using var hmac = new HMACSHA512();
         var user  = new AppUser
         {
            UserName = registerDtos.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDtos.Password)),
            PasswordSalt = hmac.Key

         };
         

         _context.Users.Add(user);
         await _context.SaveChangesAsync();
         return new UserDto
         {
           UserName =user.UserName,
           Token = _tokenService.CreateToken(user)
         };
    }


    [HttpPost("login")]//Post: api/account/register 
    
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)

    {
         var user = await _context.Users.SingleOrDefaultAsync(x => 
         x.UserName == loginDto.Username);


        if (user == null) return Unauthorized("Username Galat hai ");
        
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for ( int i =0 ; i <computedHash.Length; i++ )
        {
            if (computedHash[i] !=user.PasswordHash[i]) return Unauthorized(" sahi password dal bhai ");


        }
        return new UserDto
         {
           UserName =user.UserName,
           Token = _tokenService.CreateToken(user)
         };
        
        




    }



    private async Task<bool> UserExists  (String username)

    {
        return await _context.Users.AnyAsync(x => x.UserName==username.ToLower());

    }




}













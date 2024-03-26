

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Datingapp.Data;
using Datingapp.Extensions;
using Datingapp.interfaces;
using Datingapp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdenityServices(builder.Configuration);



 

var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200")); 
app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllers();

app.Run();

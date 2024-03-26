using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace Datingapp.DTOs
{
    public class RegisterDtos
    {
        [Required]
        public string Username {get;set;}
         [Required]
         
        public string Password {get;set;}

        
    } 
}
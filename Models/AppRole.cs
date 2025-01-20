using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class AppRole : IdentityRole
    {
        public string? Description {  get; set; }
    }
}

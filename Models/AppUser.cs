using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class AppUser : IdentityUser
    {
        public IEnumerable<WishList>? WishLists { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        public Cart? Cart { get; set; }
    }
}

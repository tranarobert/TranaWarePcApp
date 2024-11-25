using Microsoft.AspNetCore.Identity;

namespace TranaWarePc.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePhotoPath { get; set; }
    }
}

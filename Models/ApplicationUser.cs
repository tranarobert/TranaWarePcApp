using Microsoft.AspNetCore.Identity;

namespace TranaWarePcApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePhotoPath { get; set; }
    }
}

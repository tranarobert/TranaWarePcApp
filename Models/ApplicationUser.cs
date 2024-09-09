using Microsoft.AspNetCore.Identity;

namespace PawWebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? ProfilePhotoPath { get; set; }
    }
}

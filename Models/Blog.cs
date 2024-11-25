using System.ComponentModel.DataAnnotations;

namespace PawWebApp.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? PhotoPath {  get; set; }
        public string Content { get; set; }

    }
}

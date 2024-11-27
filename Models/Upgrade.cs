using System.ComponentModel.DataAnnotations;

namespace TranaWarePcApp.Models
{
    public class Upgrade
    {
        [Key]
        public int Id { get; set; }
        public string PcPart { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }

        /*public int PcComponentId { get; set; }
        public PcComponent? PcComponent { get; set; }*/

    }
}

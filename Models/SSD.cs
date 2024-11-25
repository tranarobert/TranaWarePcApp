using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranaWarePc.Models
{
    public class SSD
    {
        [Key]
        public int SSDID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string SSDName { get; set; }
        public string SSDSeries { get; set; }
        public string SSDType { get; set; }
        public string SSDFormFactor { get; set; }
        public string SSDInterface { get; set; }
        public string SSDNVMeSupport { get; set; }
        public string SSDCapacity { get; set; }
        public string SSDMaxRead { get; set; }
        public string SSDMaxWrite { get; set; }
        public string SSDRandom4KBRead { get; set; }
        public string SSDRandom4KBWrite { get; set; }

        public PcComponent pcComponent { get; set; }

        ICollection<PcComponent> PcComponents { get; set; }
    }
}

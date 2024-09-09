using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawWebApp.Models
{
    public class RAM
    {
        [Key]
        public int RAMID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string RAMName { get; set; }
        public string RAMSeries { get; set; }
        public string RAMMemoryType { get; set; }
        public string RAMMemCapacity { get; set; }
        public string RAMMemFrequency { get; set; }
        public string RAMDualChannel { get; set; }
        public string RAMLatency { get; set; }
        public string RAMRadiator { get; set; }
        public string RAMMemStandard { get; set; }
        public string RAMMemTension { get; set; }
        public string RAMMemTiming { get; set; }
        public string RAMMemLED { get; set; }

        public PcComponent pcComponent { get; set; }

        ICollection<PcComponent> PcComponents { get; set; }
    }
}

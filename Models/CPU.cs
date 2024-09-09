using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawWebApp.Models
{
    public class CPU
    {
        [Key]
        public int CPUID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }
        

        //public string CPUName { get; set; }
        public string CPUPlatform { get; set; }
        public string CPUSocket { get; set; }
        public string CPUSeries { get; set; }
        public string CPUCore { get; set; }
        public string CPUCoreNumber { get; set; }
        public string CPUThreadNumber { get; set; }
        public string CPUBaseClock { get; set; }
        public string CPUMaxBoostClock { get; set; }
        public string CPUL3Cache { get; set; }
        public string CPUL2Cache { get; set; }
        public string CPUMaxTemp { get; set; }
        public string CPUTDP { get; set; }
        public DateTime? CPULaunchDate { get; set; }


        public PcComponent pcComponent { get; set; }

        ICollection<PcComponent> PcComponents { get; set; }
    }
}

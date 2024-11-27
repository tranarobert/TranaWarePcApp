using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranaWarePcApp.Models
{
    public class PSU
    {
        [Key]
        public int PSUID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string Name { get; set; }
        public string PSUType { get; set; }
        public string PSUPower { get; set; }
        public string PSUVents { get; set; }
        public string PSUNoise { get; set; }
        public string PSUPFC { get; set; }
        public string PSUEfficiency { get; set; }
        public string PSUCertification { get; set; }
        public string PSUDimensions { get; set; }
        public string PSUModular { get; set; }
        public string PSUPorts { get; set; }

        public PcComponent pcComponent { get; set; }

        ICollection<PcComponent> PcComponents { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranaWarePc.Models
{
    public class PCCase
    {
        [Key]
        public int PCCaseID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string PCCaseName { get; set; }
        public string PCCaseCompatibleMB { get; set; }
        public string PCCaseType { get; set; }
        public string PCCasePSUPlace { get; set; }
        public string PCCaseColor { get; set; }
        public string PCCasePSU { get; set; }
        public string PCCaseBays { get; set; }
        public string PCCaseDimensions { get; set; }
        public string PCCaseWeight { get; set; }
        public string PCCaseMesh { get; set; }
        public string PCCaseSidePanel { get; set; }
        public string PCCaseExpSlots { get; set; }
        public string PCCaseRadiatorSupport { get; set; }
        public string PCCaseOther { get; set; }
        public string PCCaseCPUCoolerHeight { get; set; }
        public string PCCaseGPUCoolerHeight { get; set; }
        public string PCCasePorts { get; set; }
        public string PCCaseCoolers { get; set; }

        public PcComponent pcComponent { get; set; }

        ICollection<PcComponent> PcComponents { get; set; }
    }
}

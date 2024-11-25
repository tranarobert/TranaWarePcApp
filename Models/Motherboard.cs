using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawWebApp.Models
{
    public class Motherboard
    {
        [Key]
        public int MotherboardID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string MotherboardName { get; set; }
        public string MotherboardFormat { get; set; }
        public string MotherboardSocket { get; set; }
        public string MotherboardChipset { get; set; }
        public string MotherboardChipsetProducer { get; set; }
        public string MotherboardChipsetModel { get; set; }
        public string MotherboardSupportedCPU { get; set; }
        public string MotherboardGraphicInterface { get; set; }
        public string MotherboardRAID { get; set; }
        public string MotherboardIntegratedGraphics { get; set; }
        public string MotherboardIntegratedAudio { get; set; }
        public string MotherboardAudioChipset { get; set; }
        public string MotherboardIntegratedNetwork { get; set; }
        public string MotherboardNetworkChipset { get; set; }
        public string MotherboardDiskSlots { get; set; }
        public string MotherboardMemoryType { get; set; }
        public string MotherboardMaxMemory { get; set; }
        public string MotherboardMemorySlots { get; set; }
        public string MotherboardMemTechnology { get; set; }
        public string MotherboardSupportedFreq { get; set; }
        public string MotherboardPCISlots { get; set; }
        public string MotherboardBackPorts { get; set; }

        public PcComponent pcComponent { get; set; }

        ICollection<PcComponent> PcComponents { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawWebApp.Models
{
    public class GPU
    {
        [Key]
        public int GPUID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string GPUName { get; set; }
        public string GPUInterface { get; set; }
        public string GPUMaxResolution { get; set; }
        public string GPUModel { get; set; }
        public string GPUCooling { get; set; }
        public string GPUSeries { get; set; }
        public string GPUTechnology { get; set; }
        public string GPUGraphicProcessor { get; set; }
        public string GPUBostClock { get; set; }
        public string GPUShaderModel { get; set; }
        public string GPUTextureUnits { get; set; }
        public string GPURasterOperators { get; set; }
        public string GPUCudaCores { get; set; }
        public string GPUMemoryType { get; set; }
        public string GPUMemorySize { get; set; }
        public string GPUMemoryBus { get; set; }
        public string GPUMemoryFrequency { get; set; }
        public string GPUHDMI { get; set; }
        public string GPUDisplayPort { get; set; }

        public PcComponent pcComponent { get; set; }
        ICollection<PcComponent> PcComponents { get; set; }
    }

}

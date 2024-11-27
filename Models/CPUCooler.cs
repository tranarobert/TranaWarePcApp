using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranaWarePcApp.Models
{
    public class CPUCooler
    {
        [Key]
        public int CPUCoolerID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string CPUCoolerName { get; set; }
        public string CPUCoolerSocket { get; set; }
        public string CPUCoolerCoolingType { get; set; }
        public string CPUCoolerBearing { get; set; }
        public string CPUCoolerNrVents { get; set; }
        public string CPUCoolerPWMVent { get; set; }
        public string CPUCoolerRotationSpeed { get; set; }
        public string CPUCoolerPumpSpeed { get; set; }
        public string CPUCoolerAirflux { get; set; }
        public string CPUCoolerNoise { get; set; }
        public string CPUCoolerPumpNoise { get; set; }
        public string CPUCoolerAirPressure { get; set; }
        public string CPUCoolerConnector { get; set; }
        public string CPUCoolerPumpConnector { get; set; }
        public string CPUCoolerWeight { get; set; }
        public string CPUCoolerDimensions { get; set; }
        public string CPUCoolerLED { get; set; }
        public string CPUCoolerLCD { get; set; }

        public PcComponent pcComponent { get; set; }

        ICollection<PcComponent> PcComponents { get; set; }
    }
}

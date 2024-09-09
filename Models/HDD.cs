using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawWebApp.Models
{
    public class HDD
    {
        [Key]
        public int HDDID { get; set; }
        [ForeignKey("PcComponent")]
        public int PcComponentId { get; set; }

        //public string HDDName { get; set; }
        public string HDDSeries { get; set; }
        public string HDDInterface { get; set; }
        public string HDDCapacity { get; set; }
        public string HDDBuffer { get; set; }
        public string HDDSpeed { get; set; }
        public string HDDFormFactor { get; set; }
        public string HDDNASRecommend { get; set; }

        public PcComponent pcComponent { get; set; }
        ICollection<PcComponent> PcComponents { get; set; }
    }
}

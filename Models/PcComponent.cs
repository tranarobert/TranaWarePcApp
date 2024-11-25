namespace TranaWarePc.Models
{
    public class PcComponent
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }

        public string Name { get; set; }
        public string PhotoFileName { get; set; }

        //public ICollection<Cart>? Carts { get; set; }

        /*public Upgrade? Upgrade { get; set; }*/ 
        public CPU? CPU { get; set; }
        public GPU? GPU { get; set; }
        public Motherboard? Motherboard { get; set; }
        public RAM? RAM { get; set; }
        public SSD? SSD { get; set; }
        public HDD? HDD { get; set; }
        public PSU? PSU { get; set; }
        public PCCase? PCCase{ get; set; }
        public CPUCooler? CPUCooler { get; set; }
        public string? ComponentType { get; set; }
    }
}

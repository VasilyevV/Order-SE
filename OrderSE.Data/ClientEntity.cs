namespace OrderSE.Data
{
    public class ClientEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string AmountInWords { get; set; }
        public double VAT { get; set; } 
        public string Base { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
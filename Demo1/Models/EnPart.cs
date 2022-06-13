namespace Demo1.Models
{
    public class EnPart
    {
        public int EnPartId { get; set; }
        public string Name { get; set; }

        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
    }
}
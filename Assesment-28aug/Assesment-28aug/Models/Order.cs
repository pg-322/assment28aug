namespace Assesment_28aug.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public  string OrederTotal { get; set; }    
        public int UserId { get; set; }
        public User user { get; set; }

        public DateTime Orderdatetime { get; set; } = DateTime.Now;
    }
}

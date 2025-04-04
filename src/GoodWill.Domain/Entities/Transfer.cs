using GoodWill.Domain.Enums;

namespace GoodWill.Domain.Entities
{
    public class Transfer
    {
        
        public long TransferId { get; set; }
        public decimal Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreatedAt { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = default!;
        public long CampaignId { get; set; }
        public Campaign Campaign { get; set; } = default!;
    }
}

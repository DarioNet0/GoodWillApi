﻿namespace GoodWill.Domain.Entities
{
    public class Campaign
    {
        public long CampaignId { get; set; }    
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; }
        public decimal AmountCollected { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public long UserId { get; set; }
        public User User { get; set; } = default!;
    }
}

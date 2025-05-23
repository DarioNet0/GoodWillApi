namespace GoodWill.Communication.Responses.Campaign
{
    public class ResponseGetFullCampaignJson
    {
        public long CampaignId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; }
        public decimal AmountCollected { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool PixPayment { get; set; } = false;
        public bool BoletoPayment { get; set; } = false;
        public bool CreditCardPayment { get; set; } = false;
        public string CoverPhoto { get; set; } = string.Empty;
        public long UserId { get; set; }
    }
}

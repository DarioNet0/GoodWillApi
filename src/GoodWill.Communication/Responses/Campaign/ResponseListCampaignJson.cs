namespace GoodWill.Communication.Responses.Campaign
{
    public class ResponseListCampaignJson
    {
        public List<CampaignJson> ResponseListCampaign { get; set; } = new List<CampaignJson>();
    }

    public class CampaignJson
    {
        public long CampaignId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; } 
        public decimal AmountCollected { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }

}

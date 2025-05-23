namespace GoodWill.Communication.Responses.Campaign
{
    public class ResponseShortCampaignJson
    {
        public long CampaignId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; }
        public decimal AmountCollected { get; set; } = 0;
        public string CoverPhoto { get; set; } = string.Empty;
    }
}

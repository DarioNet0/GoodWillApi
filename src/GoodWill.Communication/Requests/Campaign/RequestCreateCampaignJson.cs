namespace GoodWill.Communication.Requests.Campaign
{
    public class RequestCreateCampaignJson
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; }
    }
}

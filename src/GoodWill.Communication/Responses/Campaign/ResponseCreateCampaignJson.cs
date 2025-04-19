namespace GoodWill.Communication.Responses.Campaign
{
    public class ResponseCreateCampaignJson
    {
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

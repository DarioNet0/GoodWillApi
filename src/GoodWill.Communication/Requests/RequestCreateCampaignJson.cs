namespace GoodWill.Communication.Requests
{
    public class RequestCreateCampaignJson
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; }
        public decimal AmountCollected { get; set; }
    }
}

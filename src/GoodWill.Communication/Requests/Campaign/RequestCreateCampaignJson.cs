namespace GoodWill.Communication.Requests.Campaign
{
    public class RequestCreateCampaignJson
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; }
        public bool PixPayment { get; set; } = false;
        public bool BoletoPayment { get; set; } = false;
        public bool CreditCardPayment { get; set; } = false;
    }
}

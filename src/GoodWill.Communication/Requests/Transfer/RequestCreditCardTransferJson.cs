namespace GoodWill.Communication.Requests.Transfer
{
    public class RequestCreditCardTransferJson
    {
        public string CardHolderName { get; set; } = string.Empty;
        public int CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvv { get; set; }
        public decimal Amount { get; set; }
        public long CampaignId { get; set; }


    }
}

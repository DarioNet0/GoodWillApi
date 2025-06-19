namespace GoodWill.Communication.Requests.Transfer
{
    public class RequestBoletoTransferJson
    {
        public string PayerName { get; set; } = string.Empty;
        public string PayerDocument { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public long CampaignId { get; set; }
        public DateTime DueDate { get; set; }
    }
}

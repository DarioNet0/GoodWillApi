using GoodWill.Communication.Enums;

namespace GoodWill.Communication.Requests.Transfer
{
    public class RequestMakeTransferJson
    {
        public decimal Amount { get; set; }
        public TransferTypes TransferType { get; set; }
        public long UserId { get; set; }
        public long CampaignId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWill.Communication.Responses
{
    public class ResponseListCampaignJson
    {
        public long CampaignId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal TargetValue { get; set; }
        public decimal AmountCollected { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

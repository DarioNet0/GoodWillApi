using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWill.Communication.Requests.Transfer
{
    public class RequestAdsTransferJson
    {
        public long CampaignId { get; set; }
        public int AdsWatched { get; set; }
        public decimal AdPrice { get; set; } = 0.5m;
    }
}

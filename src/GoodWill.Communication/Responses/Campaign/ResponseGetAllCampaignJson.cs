namespace GoodWill.Communication.Responses.Campaign
{
    public class ResponseGetAllCampaignJson
    {
        public List<ResponseShortCampaignJson> Campaigns { get; set; } = new List<ResponseShortCampaignJson>();
    }
}

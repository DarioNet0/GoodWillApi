using GoodWill.Communication.Responses.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWill.Application.UseCases.Campaigns.ListById
{
    public interface IListByIdCampaignUseCase
    {
        Task<ResponseListCampaignJson> Execute(long searchCampaignId);

    }
}

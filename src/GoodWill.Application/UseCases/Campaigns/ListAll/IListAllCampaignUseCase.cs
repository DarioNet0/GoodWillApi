using GoodWill.Communication.Requests;
using GoodWill.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWill.Application.UseCases.Campaigns.List
{
    public interface IListCampaignUseCase
    {
        Task<ResponseListCampaignJson> Execute();

    }
}

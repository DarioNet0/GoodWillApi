<<<<<<< HEAD
﻿using GoodWill.Communication.Responses;
=======
﻿using GoodWill.Communication.Responses.Campaign;
>>>>>>> dfc9f990b3330d0c512c3ff47b3b872303f83538

namespace GoodWill.Application.UseCases.Campaigns.List
{
    public interface IListAllCampaignUseCase
    {
        Task<ResponseListCampaignJson> Execute();

    }
}

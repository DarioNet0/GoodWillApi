﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWill.Application.UseCases.Campaigns.Delete
{
    public interface IDeleteCampaignUseCase
    {
        Task<bool> Execute(long searchCampaignId);
    }
}

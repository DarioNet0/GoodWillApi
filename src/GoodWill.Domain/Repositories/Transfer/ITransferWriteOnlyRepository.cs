namespace GoodWill.Domain.Repositories.Transfer
{
    public interface ITransferWriteOnlyRepository
    {
        Task UpdateBalance(long campaignId, decimal Amoun);
    }
}

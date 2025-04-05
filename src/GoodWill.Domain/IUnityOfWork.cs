namespace GoodWill.Domain
{
    public interface IUnityOfWork
    {
        Task Commit();
    }
}

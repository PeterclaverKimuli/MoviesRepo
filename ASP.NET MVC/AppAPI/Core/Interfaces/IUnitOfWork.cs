namespace AppAPI.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}

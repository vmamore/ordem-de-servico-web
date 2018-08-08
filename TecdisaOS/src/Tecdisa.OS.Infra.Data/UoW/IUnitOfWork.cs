namespace Tecdisa.OS.Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}

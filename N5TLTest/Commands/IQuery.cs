namespace N5TLTest.Commands
{
    public interface IQuery<T, T1>
    {
        Task<T> Query(T1 param);
    }
}

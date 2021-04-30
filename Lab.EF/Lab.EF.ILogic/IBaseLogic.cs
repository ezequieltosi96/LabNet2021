namespace Lab.EF.ILogic
{
    public interface IBaseLogic<T> : IAbmLogic<T>, IQueryLogic<T> where T : class
    {
    }
}

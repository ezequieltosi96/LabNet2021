namespace Lab.EF.ILogic
{
    public interface IAbmLogic<T> where T : class
    {
        void Add(T newEntity);

        void Update(T entity);

        void Delete(int id);
    }
}

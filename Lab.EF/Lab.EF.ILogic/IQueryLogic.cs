using System.Collections.Generic;

namespace Lab.EF.ILogic
{
    public interface IQueryLogic<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(string searchString = "");
    }
}

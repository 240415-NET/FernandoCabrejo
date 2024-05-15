namespace MealsProject.DataAccessLayer
{
    using System.Collections.Generic;

    //not used currently, eventually will need it
    internal interface IRepository
    {
        T Add<T>(T entity);
        IEnumerable<T> GetAll<T>();
        bool Delete<T>(T entity);
        bool Update<T>(T entity);
        T Get<T>(int id);
    }
}
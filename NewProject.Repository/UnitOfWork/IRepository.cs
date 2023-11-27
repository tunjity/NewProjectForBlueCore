using NewProject.Domain;

namespace NewProject.Repository;
public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();

    T Get(long id);

    void Insert(T entity);

    void Update(T entity);

    void Delete(T entity);
}

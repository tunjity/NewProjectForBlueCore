

using Microsoft.EntityFrameworkCore;
using NewProject.Domain;

namespace NewProject.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly NPDbContext _context;
    private readonly DbSet<T> entities;
    private string errorMessage = string.Empty;
    public Repository(NPDbContext dbContext)
    {
        _context = dbContext;
        entities = _context.Set<T>();
    }

    public IQueryable<T> GetAll()
    {
        return entities.AsQueryable();
    }

    public T Get(long id)
    {
        return entities.FirstOrDefault(s => s.Id == id);
    }

    public void Insert(T entity)

    {
        if (entity == null)
            throw new ArgumentNullException("entity");

        entities.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        entities.Remove(entity);
        _context.SaveChanges();
    }
}

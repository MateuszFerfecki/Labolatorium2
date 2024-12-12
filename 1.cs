namespace Interfaces
{
    public interface IBaseRepository<T, TEntity> where T : IEntity<TEntity>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(TEntity id);
        List<T> GetAll();
        T Get(TEntity id);
    }
}
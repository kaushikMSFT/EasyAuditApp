using System.Threading.Tasks;

namespace AuditorAPI.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
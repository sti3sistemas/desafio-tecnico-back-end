using Desafio.Data.Helpers;

namespace Desafio.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity, new()
    {
    }
}
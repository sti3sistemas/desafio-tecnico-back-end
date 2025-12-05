using Desafio.Data.Context;
using Desafio.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Desafio.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected Contexto Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(Contexto db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TEntity>> select = null)
        {
            if (predicate != null)
            {
                if (select == null)
                {
                    return DbSet.Where(predicate).FirstOrDefault();
                }
                else
                {
                    return DbSet.Where(predicate).Select(select).FirstOrDefault();
                }
            }

            if (select != null)
            {
                return DbSet.Select(select).FirstOrDefault();
            }

            return await DbSet.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsNoTracking(Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TEntity>> select = null)
        {
            if (predicate != null)
            {
                if (select == null)
                {
                    return DbSet.AsNoTracking().Where(predicate).FirstOrDefault();
                }
                else
                {
                    return DbSet.AsNoTracking().Where(predicate).Select(select).FirstOrDefault();
                }
            }

            if (select != null)
            {
                return DbSet.AsNoTracking().Select(select).FirstOrDefault();
            }

            return await DbSet.AsNoTracking().FirstOrDefaultAsync();
        }
            
        public async Task<TEntity> First(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).FirstAsync();
        }

        public async Task<TEntity> First()
        {
            return await DbSet.FirstAsync();
        }

        public async Task<TEntity> FirstAsNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).FirstAsync();
        }

        public virtual async Task<TEntity> FindByKey(params object[] keyValues)
        {
            return await DbSet.FindAsync(keyValues);
        }

        public async Task<IEnumerable<TEntity>> FindAllSelect(Expression<Func<TEntity, TEntity>> select)
        {
            return await DbSet.Select(select).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllSelectAsNoTracking(Expression<Func<TEntity, TEntity>> select)
        {
            return await DbSet.AsNoTracking().Select(select).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllSelectAsNoTracking(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> select)
        {
            return await DbSet.AsNoTracking().Where(predicate).Select(select).ToListAsync();
        }

        public virtual async Task<List<TEntity>> FindAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<List<TEntity>> FindAllAsNoTracking()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AnyAsync(predicate);
        }

        public virtual async Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task InsertRange(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            await SaveChanges();
        }

        public virtual async Task Delete(params object[] keyValues)
        {
            var entity = await FindByKey(keyValues);

            if (entity != null)
                DbSet.Remove(entity);

            await SaveChanges();
        }

        public virtual async Task DeleteRange(List<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            await SaveChanges();
        }

        public void SetConnectionString(string connectionString)
        {
            Db.Database.SetConnectionString(connectionString);
        }


        public async Task<int> SaveChanges()
        {
            var sucesso = await Db.SaveChangesAsync();
            var modificado = Db.ChangeTracker.Entries().Any(x => x.State.Equals(EntityState.Added | EntityState.Deleted | EntityState.Modified));
            
            return sucesso;
        }

        public Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public void DetectChangesTracker(bool detect)
        {
            Db.ChangeTracker.AutoDetectChangesEnabled = detect;
        }

        public void RejectChanges()
        {
            foreach (var entry in Db.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}

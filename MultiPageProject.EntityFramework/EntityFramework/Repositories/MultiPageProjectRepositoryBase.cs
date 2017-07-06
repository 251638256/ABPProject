using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MultiPageProject.EntityFramework.Repositories
{
    public abstract class MultiPageProjectRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MultiPageProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MultiPageProjectRepositoryBase(IDbContextProvider<MultiPageProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MultiPageProjectRepositoryBase<TEntity> : MultiPageProjectRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MultiPageProjectRepositoryBase(IDbContextProvider<MultiPageProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}

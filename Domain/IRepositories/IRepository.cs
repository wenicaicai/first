using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.IRepositories
{
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        #region 属性
        IQueryable<TEntity> Entities { get; }
        #endregion

        #region 方法
        int Insert(TEntity entity);

        int Insert(IEnumerable<TEntity> entities);

        int Delete(object id);

        int Delete(TEntity entity);

        int Delete(IEnumerable<TEntity> entities);

        TEntity GetByKey(object key);

        #endregion
    }
}

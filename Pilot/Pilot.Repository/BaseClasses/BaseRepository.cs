using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqToDB;
using Pilot.DataCore;
using Pilot.DataCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Repository.BaseClasses
{
    public abstract class BaseRepository <TEntity, TDto>  where TEntity : class, IEntity  where TDto : class
    {
        protected readonly DataManager _dataManager;

        protected BaseRepository(DataManager dataManager, IMapper mapper = null)
        {
            _dataManager = dataManager;
        }

        /// <summary>
        /// Получить все TEntity (без удалённых)
        /// </summary>
        /// <param name="extraWhere"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetEntityIQueriable(Expression<Func<TEntity, bool>> extraWhere = null)
        {
            var query = _dataManager.GetTable<TEntity>().Where(x => !x.Deleted.HasValue);
            if (extraWhere != null)
                query = query.Where(extraWhere);
            return query;
        }

        /// <summary>
        /// Получить все TDto (без удалённых)
        /// </summary>
        /// <returns></returns>
        public async virtual Task<ICollection<TDto>> GetDtoAll()
        {
            var table = _dataManager.GetTable<TEntity>().Where(x=> !x.Deleted.HasValue);
            return await table.ProjectTo<TDto>().ToListAsync();
        }


        /// <summary>
        /// Получить Dto по Id (без удалённых)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async virtual Task<TDto> GetDtoById(Guid id)
        {
            return await GetEntityIQueriable(x=>x.Id == id).ProjectTo<TDto>().FirstOrDefaultAsync();
        }
    }
}

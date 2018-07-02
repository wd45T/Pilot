using Pilot.DataCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Repository.Interfaces.Common
{
    public interface ICRUIDRepository<TEntity, TDto> : IDisposable where TEntity : IEntity where TDto : class
    {
        Task<ICollection<TDto>> GetDtoAll();
        Task<TDto> GetDtoById(Guid id);
        Task<int> Create(TEntity entity);
        //Task<TEntity> GetEntityById(long id, string userLogin = null);
        //Task<ICollection<TDto>> GetByIds(IEnumerable<long> ids, string userLogin = null);
    }
}

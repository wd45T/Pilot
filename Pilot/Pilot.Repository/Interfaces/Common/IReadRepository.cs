using Pilot.DataCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pilot.Repository.Interfaces.Common
{
    public interface IReadRepository<TEntity, TDto> : IDisposable where TEntity : IEntity where TDto : class
    {
        Task<ICollection<TDto>> GetDtoAll();
        Task<TDto> GetDtoById(Guid id);
        //Task<TEntity> GetEntityById(long id, string userLogin = null);
        //Task<ICollection<TDto>> GetByIds(IEnumerable<long> ids, string userLogin = null);
    }
}

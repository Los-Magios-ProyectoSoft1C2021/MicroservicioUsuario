using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Commands
{
    public interface IGenericsRepository
    {
        Task Add<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Remove<T>(T entity) where T : class;
    }
}

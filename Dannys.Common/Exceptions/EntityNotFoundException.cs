using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public class EntityNotFoundException<TEntity> : Exception where TEntity : class
    {
        public EntityNotFoundException(int id) : base($"The {nameof(TEntity)} with id {id} is not found") { }
    }
}

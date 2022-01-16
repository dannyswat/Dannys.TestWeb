using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common
{
    public class DuplicatedKeyException<TEntity> : Exception where TEntity : class
    {
        public DuplicatedKeyException(string transactionNumber) : base($"The key {transactionNumber} already exists in {nameof(TEntity)}") { }
    }
}

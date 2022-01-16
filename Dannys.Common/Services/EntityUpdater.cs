using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dannys.Common.Services
{
    public class EntityUpdater
    {
        List<PropertyInfo> parseCopyableProperties(Type type)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();

            foreach (PropertyInfo member in type.GetProperties())
            {
                if (member.GetCustomAttribute<NonUpdatableAttribute>() == null)
                    result.Add(member);
            }

            return result;
        }

        public void CopyValue<TEntity>(TEntity dest, TEntity source)
        {
            foreach (var member in parseCopyableProperties(typeof(TEntity)))
            {
                member.SetValue(dest, member.GetValue(source));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProjectTemplate.Domain.Commons
{
    public abstract class AggregateRoot<T> : BaseEntity<T>
    {
        public AggregateRoot(T id) : base(id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureProjectTemplate.Domain.Commons
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; private set; }

        public BaseEntity(T id)
        {
            Id = id;
        }
    }
}

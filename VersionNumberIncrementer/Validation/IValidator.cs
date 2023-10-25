using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionNumberIncrementer.Validation
{
    public interface IValidator<T>
    {
        public bool Validate(T value);
    }
}

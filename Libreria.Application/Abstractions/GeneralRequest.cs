using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Application.Abstractions
{
    internal interface GeneralRequest<T> where T : class
    {
        public T toEntity();
    }
}

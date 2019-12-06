using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleImplementations
{
    public interface IService {
        string Name { get; }
        string hello();
    }
}

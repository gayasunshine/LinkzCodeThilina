using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace LynksCodePuzzle.DependancyResolver
{
   public interface IdependancyResolver : IDependencyScope, IDisposable
    {
        IDependencyScope BeginScope();

    }

 
}

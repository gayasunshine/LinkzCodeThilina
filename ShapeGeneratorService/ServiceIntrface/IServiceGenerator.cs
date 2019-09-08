using ShapeGeneratorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeGeneratorService.ServiceIntrface
{
  public interface IServiceGenerator
    {

        Shape ValidateShape(string userInput);
        


    }
}

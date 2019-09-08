using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeGeneratorService.Model
{
   public  class Shape
    {
        public string shapeName { get; set; }
      

        public bool isIdentified { get; set; }

        public string responceMessage { get; set; }

        public bool isParametersMatched { get; set; }

        //public string shapeType { get; set; }


        public ShapeType shapeType { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public int sideLength { get; set; }



    }
}

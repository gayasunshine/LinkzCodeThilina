using ShapeGeneratorService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LynksCodePuzzle.Models
{
    public class ClientShape
    {
        public string userInput { get; set; }

        public string shapeName { get; set; }


        public bool isIdentified { get; set; }

        public string responceMessage { get; set; }

        public bool isParametersMatched { get; set; }

        //public string shapeType { get; set; }


        public string shapeType { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public int sideLength { get; set; }




        // public int shapeWidth { get; set; }

        // public int shapeHeight { get; set; }
    }
}
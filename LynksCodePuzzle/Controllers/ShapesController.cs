using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using LynksCodePuzzle.Models;
using ShapeGeneratorService.ServiceIntrface;
using ShapeGeneratorService.Model;


namespace LynksCodePuzzle.Controllers
{
    public class ShapesController : ApiController
    {


        //Dependency Injection Initialization
        private IServiceGenerator _service;

        public ShapesController(IServiceGenerator service)
        {
            _service = service;
        }
        //GET: api/Shapes/5
        public string Get(int id)
        {
            return "value";
        }


        


        // POST: api/Shapes
        [ResponseType(typeof(ClientShape))]

        public IHttpActionResult Post(ClientShape clientShape)
        {

            Shape s = new Shape();

            if (_service != null)
                s = _service.ValidateShape(clientShape.userInput);

            clientShape.shapeName = s.shapeName;
            clientShape.isIdentified = s.isIdentified;
            clientShape.isParametersMatched = s.isParametersMatched;
            clientShape.responceMessage = s.responceMessage;
            clientShape.shapeType = s.shapeType.ToString();
            clientShape.sideLength = s.sideLength;
            clientShape.height = s.height;
            clientShape.width = s.width;




            return CreatedAtRoute("DefaultApi", new { ShapeNme = clientShape.shapeName, isIdentified  = clientShape.isIdentified , responceMessage  = clientShape.responceMessage, isParametersMatched  = clientShape.isParametersMatched, shapeType  = clientShape.shapeType , height  =clientShape.height, width =clientShape.width, sideLength =clientShape.sideLength}, s);
            
        }



       
    }
}


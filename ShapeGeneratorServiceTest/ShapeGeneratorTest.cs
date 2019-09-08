using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeGeneratorService.Model;
using ShapeGeneratorService.Service;

namespace ShapeGeneratorServiceTest
{
    [TestClass]
    public class ShapeGeneratorTest
    {
        [TestMethod]
        public void IsValiedShape()
        {
            Shape shape = new Shape();
            string userInput = "Draw a square with a side length of 200";
            ServiceGenerator service = new ServiceGenerator();
            string actualValue = "Square";
            shape = service.ValidateShape(userInput);
            string expectedValue = shape.shapeName;
            Assert.AreEqual(expectedValue, actualValue,true);
            
            
        }

        [TestMethod]
        public void IsValiedProperties()
        {
            Shape shape = new Shape();
            string userInput = "Draw a square with a side length of 200";
            ServiceGenerator service = new ServiceGenerator();
            bool isPropertyMatched = true;
            shape = service.ValidateShape(userInput);
            bool expectedValue = shape.isParametersMatched;
            Assert.AreEqual(expectedValue, isPropertyMatched);


        }

        [TestMethod]
        public void IsShapeCreatd()
        {
            Shape shape = new Shape();
            string userInput = "Draw a square with a side length of 200";
            ServiceGenerator service = new ServiceGenerator();
            string responceMassage = "Shape Created";
            shape = service.ValidateShape(userInput);
            string expectedValue = shape.responceMessage;
            Assert.AreEqual(expectedValue, responceMassage);


        }

        [TestMethod]
        public void IsShapenotCreated()
        {
            Shape shape = new Shape();
            string userInput = "Draw a  with a side length of 200";
            ServiceGenerator service = new ServiceGenerator();
            string responceMassage = "Shape not Created";
            shape = service.ValidateShape(userInput);
            string expectedValue = shape.responceMessage;
            Assert.AreEqual(expectedValue, responceMassage);


        }


    }
}

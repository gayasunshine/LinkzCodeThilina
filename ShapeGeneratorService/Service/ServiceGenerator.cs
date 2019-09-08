using ShapeGeneratorService.Model;
using ShapeGeneratorService.ServiceIntrface;
using ShapeGeneratorService.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShapeGeneratorService.Service
{
    public class ServiceGenerator : IServiceGenerator
    {
        //Constant Variables

        public const string UserRequestAction = "draw";
        public const string SecondPortion = "a";
        public const string Shapes = "IsoscelesTriangle,Square,ScaleneTriangle,Parallelogram,EquilateralTriangle,Pentagon,Rectangle,Hexagon,circle,octagon";
        public const string Properties = "radius,sidelength,width,height";
        public const string SideLengthEqulizeProperty = "sidelength";
        public const string ResponseMessegeSucsess = "Shape Created";
        public const string ResponseMessegeFaild = "Shape not Created";
        public const string WidthProperty = "width";
        public const string HeightProperty = "height";


        public Shape ValidateShape(string userInput)
        {
            string validatedShape = string.Empty;
            string lastPortion = string.Empty;
            Shape shape = new Shape();
            try
            {

                //Format the User Input
                if (userInput != null)
                {
                    userInput = Helper.FormatUserInput(userInput);
                    bool isValiedInput = ValidateUserInputFormat(userInput);
                    //Validating first portion of the User input is correct or not
                    if (isValiedInput)
                    {
                        //Validate the Shape Object that User Entered
                        List<string> posibleShapes = Helper.AllPossibleKeyValues(Shapes);
                        validatedShape = GetValidatedShape(posibleShapes, userInput);

                        if(validatedShape == "")
                        {
                            shape.isIdentified = false;
                            shape.responceMessage = ResponseMessegeFaild;
                        }
                        //Get the Last Portion of the UserInput to process Property resolver
                        lastPortion = Helper.GetLastPortionofUserInput(userInput, validatedShape);
                        if (lastPortion != "")
                        {
                            shape = getRequestedShape(PropertyResolver(lastPortion), validatedShape);
                        }

                        if(!shape.isParametersMatched)
                        {
                            shape.isIdentified = false;
                            shape.responceMessage = ResponseMessegeFaild;
                        }

                    }

                    else
                    {
                        shape.isIdentified = false;
                        shape.responceMessage = ResponseMessegeFaild;
                    }


                }

                else
                {
                    shape.isIdentified = false;
                    shape.responceMessage = ResponseMessegeFaild;
                }

                

            }



            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            return shape;

        }

        private bool ValidateUserInputFormat(string userInput)
        {
            try
            {
                //Return value for is validated or not
                bool isUserInputValidated;
                //Variable for hold second portion of user input before the shape
                string secondPortion = userInput.Substring(4, 1);
                //Validate first portion of the User Input is correct before the shape identified.
                isUserInputValidated = userInput.Contains(UserRequestAction);
                //Checking the second portion before the Shape
                if (isUserInputValidated)
                {
                    isUserInputValidated = userInput.Contains(SecondPortion);
                }

                else
                {
                    isUserInputValidated = false;
                }






                return isUserInputValidated;
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
        }


        //Get Validated Shape from User Input
        private string GetValidatedShape(List<string> allPosibleShapes, string userInput)
        {
            try
            {
                bool isValidShape;
                string valiedShape = string.Empty;
                if (allPosibleShapes.Count > 0)
                {
                    foreach (string shape in allPosibleShapes)
                    {
                        isValidShape = userInput.Contains(shape);
                        if (isValidShape)
                        {
                            valiedShape = shape;
                            break;
                        }
                    }
                }

                return valiedShape;

            }

            catch (ArgumentNullException ex)
            {
                throw ex;
            }


        }
        //Return Propertis of the requested shape
        private IDictionary<string, int> PropertyResolver(string userInputLastPortion)
        {
            Dictionary<string, int> properties = new Dictionary<string, int>();
            List<int> mesurements = new List<int>();
            bool isValidProperty;
            try
            {

                //Get all Posible Properties
                List<string> posibleProperties = Helper.AllPossibleKeyValues(Properties);
                //Get Mesurements
                mesurements = Helper.GetMesurements(userInputLastPortion);
                if (posibleProperties.Count > 0 && mesurements.Count > 0)
                {
                    foreach (string prop in posibleProperties)
                    {
                        isValidProperty = userInputLastPortion.Contains(prop);
                        if (isValidProperty)
                        {
                            foreach (int mesurement in mesurements)
                            {
                                properties.Add(prop, mesurements[mesurements.IndexOf(mesurement)]);
                                mesurements.Remove(mesurement);
                                break;
                            }

                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }


            return properties;
        }
        //Fill the shape Properties 
        public Shape getRequestedShape(IDictionary<string, int> properties, string shapeName)
        {

            Shape shape = new Shape();
            if (ShapeType.EquilateralTriangle.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {

                foreach (var item in properties)
                {
                    if (item.Key == SideLengthEqulizeProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.sideLength = item.Value;
                        shape.shapeType = ShapeType.EquilateralTriangle;
                        shape.shapeName=(ShapeType.EquilateralTriangle.ToString());

                    }

                    else
                    {
                        shape.isParametersMatched = false;
                        shape.responceMessage = ResponseMessegeFaild;

                    }
                }
            }

            else if (ShapeType.Square.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var item in properties)
                {
                    if (item.Key == SideLengthEqulizeProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.sideLength = item.Value;
                        shape.shapeType = ShapeType.Square;
                        shape.shapeName=(ShapeType.Square.ToString());

                    }

                    else
                    {
                        shape.isParametersMatched = false;
                        shape.responceMessage = ResponseMessegeFaild;
                    }
                }
            }

            else if (ShapeType.IsoscelesTriangle.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var item in properties)
                {
                    if (item.Key == WidthProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.width = item.Value;
                        shape.shapeType = ShapeType.IsoscelesTriangle;
                        shape.shapeName=(ShapeType.IsoscelesTriangle.ToString());

                    }

                    

                    if (item.Key == HeightProperty)
                    {
                        shape.height = item.Value;
                    }

                   
                }


               
            }


            else if (ShapeType.ScaleneTriangle.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var item in properties)
                {
                    if (item.Key == SideLengthEqulizeProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.sideLength = item.Value;
                        shape.shapeType = ShapeType.ScaleneTriangle;
                        shape.shapeName=(ShapeType.ScaleneTriangle.ToString());

                    }
                    else
                    {
                        shape.isParametersMatched = false;
                        shape.responceMessage = ResponseMessegeFaild;
                    }


                }



            }

            else if (ShapeType.Rectangle.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var item in properties)
                {
                    if (item.Key == WidthProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.width = item.Value;
                        shape.shapeType = ShapeType.Rectangle;
                        shape.shapeName = (ShapeType.Rectangle.ToString());

                    }
                    if (item.Key == HeightProperty)
                    {
                        shape.height = item.Value;
                    }


                }



            }



            else if (ShapeType.Parallelogram.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var item in properties)
                {
                    if (item.Key == SideLengthEqulizeProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.sideLength = item.Value;
                        shape.shapeType = ShapeType.Parallelogram;
                        shape.shapeName=(ShapeType.Parallelogram.ToString());

                    }

                    else
                    {
                        shape.isParametersMatched = false;
                        shape.responceMessage = ResponseMessegeFaild;
                    }
                }
            }

            else if (ShapeType.Pentagon.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var item in properties)
                {
                    if (item.Key == SideLengthEqulizeProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.sideLength = item.Value;
                        shape.shapeType = ShapeType.Pentagon;
                        shape.shapeName=(ShapeType.Pentagon.ToString());

                    }

                    else
                    {
                        shape.isParametersMatched = false;
                        shape.responceMessage = ResponseMessegeFaild;
                    }
                }
            }

            else if (ShapeType.Hexagon.ToString().Equals(shapeName, StringComparison.InvariantCultureIgnoreCase))
            {
                foreach (var item in properties)
                {
                    if (item.Key == SideLengthEqulizeProperty)
                    {
                        //Fill the Object
                        shape.isIdentified = true;
                        shape.isParametersMatched = true;
                        shape.responceMessage = ResponseMessegeSucsess;
                        shape.sideLength = item.Value;
                        shape.shapeType = ShapeType.Hexagon;
                        shape.shapeName=(ShapeType.Hexagon.ToString());

                    }

                    else
                    {
                        shape.isParametersMatched = false;
                        shape.responceMessage = ResponseMessegeFaild;
                    }
                }
            }

            else
            {
                shape.isIdentified = false;
            }

            return shape;




        }
    }
}

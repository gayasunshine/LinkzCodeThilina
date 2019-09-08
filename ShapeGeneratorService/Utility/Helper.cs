using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShapeGeneratorService.Utility
{
    public static class Helper
    {
      

        public static string FormatUserInput(string userInput)
        {
            //To lower case to all user input text
            userInput = userInput.ToLower();
            //Replace the Whitespaces of the text
            userInput = userInput.Replace(" ", String.Empty);
            return userInput;
        }

        public static List<string> AllPossibleKeyValues(string posibleKeys)
        {
            List<string> keyList = null;
            string keys = posibleKeys;
            keys = FormatUserInput(posibleKeys);
            keyList = keys.Split(',').ToList<string>();
            return keyList;


        }

        //Return last portion of the UserInput after shape value
        public static string GetLastPortionofUserInput(string userInput , string shapeName)
        {
            string lastPortion = string.Empty;
            if (userInput != "" && shapeName != "")
            {
                
                lastPortion = userInput.Substring(userInput.LastIndexOf(shapeName), userInput.Length - (userInput.LastIndexOf(shapeName)));
                lastPortion = lastPortion.Replace(shapeName, "");
            }
            return lastPortion;
        }

        //Return Integer List of Mesurements of User Input Last Portion
        public static List<int> GetMesurements(string lastPortion)
        {
            List<int> mesurements = new List<int>();
            string[] numbers = Regex.Split(lastPortion, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    int i = int.Parse(value);
                    mesurements.Add(i);
                }
            }
            return mesurements;
        }
    }
}

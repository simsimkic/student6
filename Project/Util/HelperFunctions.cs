using System.IO;
using System;

namespace Project.Util
{
    public class HelperFunctions
    {
        // TODO: Change the way it reads lines when we change the file ext

        public static string[] ReadFile(string fileName){
            return File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
        }

        public static int ConvertIDToInt(string id){
            return Int32.Parse(id);

        }

    }
}
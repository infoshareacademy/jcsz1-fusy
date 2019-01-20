using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Loader
    {
        private String PathToFile = @"WalutyBusinessLogic\LoadingFromFile\FilesToLoad\omeganbp";

        public Currency LoadFromFile(string fileName)
        {
            return null;
        }

        private StreamReader LoadStreamFromFile(string fileName)
        {
            StreamReader reader;

            PathToFile = Path.Combine(PathToFile, fileName);
            PathToFile = Path.Combine(Directory.GetParent
                                     (Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,
                                     PathToFile);           
            if (File.Exists(PathToFile))
            {
                reader = File.OpenText(PathToFile);     
            }
            else
            {
                throw new FileLoadException();
            }
            return  reader;
        }
    }
}

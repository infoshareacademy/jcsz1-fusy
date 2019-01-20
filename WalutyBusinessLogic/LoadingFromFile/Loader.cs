using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Loader
    {
        private String PathToFile = @"..\\LoadingFromFile\FilesToLoad\omeganbp";

        public StreamReader LoadFromFile(string fileName)
        {
            PathToFile = PathToFile + @"\" + fileName + ".txt";
            PathToFile = Path.GetFullPath(PathToFile);
            PathToFile = @"C:\Users\Dariusz J\Documents\Repos\Projekt\jcsz1 - fusy\WalutyBusinessLogic\LoadingFromFile\FilesToLoad\omeganbp\gbp.txt";

            if (File.Exists(PathToFile))
            {
                StreamReader streamReader = File.OpenText(PathToFile);
            }
            else
            {
                throw new FileLoadException();
            }

            return  null;
        }
    }
}

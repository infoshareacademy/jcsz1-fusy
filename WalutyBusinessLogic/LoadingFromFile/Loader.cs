using System;
using System.Collections.Generic;
using System.IO;


namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Loader
    {
        private string PathToDirectory = @"WalutyBusinessLogic\LoadingFromFile\FilesToLoad\omeganbp";
        private string Separator = ",";

        public Currency LoadCurrencyFromFile(string fileName)
        {
            List<string> linesFromFile = LoadLinesFromFile(fileName);
            return GetCurrency(linesFromFile);
        }

        public List<Currency> GetListOfAllCurrencies()
        {
            List<Currency> currencies = new List<Currency>();

            foreach(string currencyFileName in GetAvailableTxtFileNames())
            {
                currencies.Add(LoadCurrencyFromFile(currencyFileName));
            }
            return currencies;
        }

        public List<string> GetAvailableTxtFileNames()
        {
            string pathToDirectory = Path.Combine(Directory.GetParent
                                                 (Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName
                                                 ,PathToDirectory);          
            string[] filePaths = Directory.GetFiles(pathToDirectory, "*.txt", SearchOption.TopDirectoryOnly);
            List<string> listOfFileNames = new List<string>();

            foreach(string line in filePaths)
            {
                listOfFileNames.Add(Path.GetFileName(line));
            }
           
            return listOfFileNames;
        }

        private List<string> LoadLinesFromFile(string fileName) 
        {
            string pathToFile = PathToDirectory;
            StreamReader streamReader;
            List<string> listOfLines = new List<string>();

            pathToFile = Path.Combine(pathToFile, fileName);
            pathToFile = Path.Combine(Directory.GetParent
                                     (Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,
                                      pathToFile);

            if (File.Exists(pathToFile))
            {
                streamReader = File.OpenText(pathToFile);
            }
            else
            {
                throw new FileLoadException();
            }

            //Ignore first line from currenty data
            if (!streamReader.EndOfStream)
            {
                streamReader.ReadLine();
            }

            while (!streamReader.EndOfStream)
            {
                listOfLines.Add(streamReader.ReadLine());
            }

            return listOfLines;

        }

        private Currency GetCurrency(List<string> listOfLines)
        {
            string[] splittedLine;
            Currency currency = new Currency();

            for(int i = 0; i < listOfLines.Count; i++)
            {
                CurrencyRecord currencyRecord = new CurrencyRecord();
                splittedLine = listOfLines[i].Split(Separator);
          
                if (i == 0)
                {
                    currency.Name = splittedLine[0];
                }
                try
                {
                    currencyRecord.Date = Convert.ToInt32(splittedLine[1]);
                    currencyRecord.Open = float.Parse(splittedLine[2].Replace(".",","));
                    currencyRecord.High = float.Parse(splittedLine[3].Replace(".", ","));
                    currencyRecord.Low = float.Parse(splittedLine[4].Replace(".", ","));
                    currencyRecord.Close = float.Parse(splittedLine[5].Replace(".", ","));
                    currencyRecord.Volume = float.Parse(splittedLine[6].Replace(".", ","));
                }
                catch(FormatException e)
                {
                    Console.WriteLine("error loading file at line: " + i);
                    Console.WriteLine(e.Message);
                }
                currency.ListOfRecords.Add(currencyRecord);
            }
            return currency;
        }
    }
    
}

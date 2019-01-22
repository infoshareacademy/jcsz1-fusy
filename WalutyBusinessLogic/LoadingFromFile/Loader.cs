using System;
using System.Collections.Generic;
using System.IO;


namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Loader
    {
        private String PathToDirectory = @"WalutyBusinessLogic\LoadingFromFile\FilesToLoad\omeganbp";
        private String Separator = ",";

        public Currency LoadCurrencyFromFile(string fileName)
        {
            StreamReader streamReaderFromFile = LoadStreamFromFile(fileName);
            List<string> linesFromFile = GetLinesFromStreamReader(streamReaderFromFile);
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

        private StreamReader LoadStreamFromFile(string fileName)
        {
            string pathToFile = PathToDirectory;
            StreamReader reader;

            pathToFile = Path.Combine(pathToFile, fileName);
            pathToFile = Path.Combine(Directory.GetParent
                                     (Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,
                                      pathToFile);   
            
            if (File.Exists(pathToFile))
            {
                reader = File.OpenText(pathToFile);     
            }
            else
            {
                throw new FileLoadException();
            }
            return  reader;
        }

        private List<string> GetLinesFromStreamReader(StreamReader streamReader)
        {
            List<string> listOfLines = new List<string>();

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
            CurrencyRecord currencyRecord;

            for(int i = 0; i < listOfLines.Count; i++)
            {
                currencyRecord = new CurrencyRecord();
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
                catch(System.FormatException e)
                {
                    Console.WriteLine("error loading file at line: " + i);
                    Console.ReadKey();
                }
                currency.ListOfRecords.Add(currencyRecord);
            }
            return currency;
        }
    }
    
}

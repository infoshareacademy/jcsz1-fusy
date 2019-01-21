using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Loader
    {
        private String PathToFile = @"WalutyBusinessLogic\LoadingFromFile\FilesToLoad\omeganbp";
        private String Separator = ",";

        public Currency LoadFromFile(string fileName)
        {
            StreamReader streamReader = LoadStreamFromFile(fileName);
            List<string> readedFile = GetLinesFromStreamReader(streamReader);
            return GetCurrency(readedFile);
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
                    Console.WriteLine("error loading code at line: " + i);
                    Console.ReadKey();
                }

                currency.ListOfRecords.Add(currencyRecord);

            }

            return currency;
        }
    }
    
}
